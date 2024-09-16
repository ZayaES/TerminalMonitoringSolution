using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using TerminalMonitoringSolution.DataAccess;
using TerminalMonitoringSolution.IServices;
using TerminalMonitoringSolution.Models;
using TerminalMonitoringSolution.Views;

namespace TerminalMonitoringSolution.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AdminIdentity> _userManager;
        private readonly RoleManager<UserIdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _emailService;
        public AccountService(UserManager<AdminIdentity> userManager, RoleManager<UserIdentityRole> roleManager,
                                IConfiguration congiguration, IHttpContextAccessor httpContextAccessor, IEmailService emailService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = congiguration;
            _httpContextAccessor = httpContextAccessor;
            _emailService = emailService;
        }

        public async Task<AccountResponse> RegisterUser(RegistrationDTO user)
        {
            AccountResponse response = new AccountResponse();
            AdminIdentity newUser = new AdminIdentity
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                UserName = user.UserName ?? user.Email,
                Email = user.Email
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);
            if (!result.Succeeded)
            {
                response.Successful = false;
                response.ErrorMessage = result.Errors.ToString();
                return response;
            }

            List<Claim> claimList = [];
            claimList.Add(new Claim(ClaimTypes.Email, user.Email));
            claimList.Add(new Claim(ClaimTypes.Name, user.UserName ?? user.FirstName));
            var claimCreate = await _userManager.AddClaimsAsync(newUser, claimList);

            if (!claimCreate.Succeeded)
            {
                response.Successful = false;
                response.ErrorMessage = "Some error occurred while creating user";
            }

            IdentityResult roleAdd;
            if (user.IsSuperAdmin)
                roleAdd = await _userManager.AddToRolesAsync(newUser, new List<string>() { "SuperAdmin", "Admin" });
            else
                roleAdd = await _userManager.AddToRoleAsync(newUser, "Admin");

            if (!roleAdd.Succeeded)
            {
                response.Successful = false;
                response.ErrorMessage = "Some error occurred while creating user";
            }

            HttpRequest request = _httpContextAccessor.HttpContext.Request;
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            string encodedToken = WebUtility.UrlEncode(token);
            string baseUrl = $"{request.Scheme}://{request.Host}";
            string confirmationLink = $"{baseUrl}/api/v1/Account/confirmEmail?token={encodedToken}&email={newUser.Email}";

            var htmlBody = await LoadHtmlTemplateAsync("wwwroot\\ConfirmationEmailTemplate.html");
            htmlBody = htmlBody.Replace("{{ConfirmationLink}}", confirmationLink);
            var subject = "Please confirm your email";

            await _emailService.SendEmailAsync(newUser.Email, subject, htmlBody);

            AdminIdentity? userGet = await _userManager.FindByEmailAsync(newUser.Email);
            if (userGet == null)
            {
                response.Successful = false;
                response.ErrorMessage = "Could not fetch user created";
                return response;
            }
            string middleName = string.IsNullOrWhiteSpace(userGet.MiddleName) ? "" : userGet.MiddleName + " ";
            response.Successful = true;
            response.Admin = new List<AdminDTO>()
            {
                new AdminDTO {  FullName = $"{userGet.FirstName} {middleName}{userGet.LastName}",
                                Email = userGet.Email,
                                Username = userGet.UserName}
            };

            return response;
        }

        public async Task<AccountResponse> ConfirmEmail(string token, string email)
        {
            AccountResponse response = new AccountResponse();
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(email))
            {
                response.Successful = false;
                response.ErrorMessage = "token or email not submitted";
                return response;
            }
            AdminIdentity? userGet = await _userManager.FindByEmailAsync(email);
            if (userGet == null)
            {
                response.Successful = false;
                response.ErrorMessage = "User does not exist";
                return response;
            }
            IdentityResult userConfirm = await _userManager.ConfirmEmailAsync(userGet, token);
            if (!userConfirm.Succeeded)
            {
                response.Successful = false;
                response.ErrorMessage = "Error confirming email address";
                return response;
            }

            string middleName = string.IsNullOrWhiteSpace(userGet.MiddleName) ? "" : userGet.MiddleName + " ";
            response.Successful = true;
            response.Admin = new List<AdminDTO>()
            {
                new AdminDTO { FullName = $"{userGet.FirstName} {middleName}{userGet.LastName}",
                                Email = userGet.Email,
                                Username = userGet.UserName}
            };

            return response;
        }

        public async Task<AccountResponse> Login(LoginModel loginCred)
        {
            AccountResponse response = new AccountResponse();
            if (string.IsNullOrEmpty(loginCred.Email) || string.IsNullOrEmpty(loginCred.Password))
            {
                response.Successful = false;
                response.ErrorMessage = "token or email not submitted";
                return response;
            }

            AdminIdentity? userGet = await _userManager.FindByEmailAsync(loginCred.Email);
            if (userGet == null)
            {
                response.Successful = false;
                response.ErrorMessage = "User does not exist";
                return response;
            }

            if(userGet.EmailConfirmed == false)
            {
                response.Successful = false;
                response.ErrorMessage = "Email has not been verified";
                return response;
            }

            bool passwordCheck = await _userManager.CheckPasswordAsync(userGet, loginCred.Password);
            if (!passwordCheck)
            {
                response.Successful = false;
                response.ErrorMessage = "Password incorrect";
                return response;
            }

            IList<Claim> userClaims = await _userManager.GetClaimsAsync(userGet);
            var userRoles = await _userManager.GetRolesAsync(userGet);

            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userGet.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            authClaims.AddRange(userClaims);
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            try
            {
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: _configuration["JwtSettings:Issuer"],
                    audience: _configuration["JwtSettings:Audience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
                var returnToken = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                };

                response.Successful = true;
                response.token = returnToken;
            }
            catch
            {

            }

           

            

            

            return response;
        }

        private async Task<string> LoadHtmlTemplateAsync(string filePath)
        {
            var absolutePath = Path.Combine(Directory.GetCurrentDirectory(), filePath);

            return await File.ReadAllTextAsync(absolutePath);
        }

        public async Task CreateRole(string roleName)
        {
            IdentityResult roleCreate = await _roleManager.CreateAsync(new UserIdentityRole { Name = roleName });
        }

    }
}
