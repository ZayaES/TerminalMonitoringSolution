using Microsoft.AspNetCore.Mvc;
using TerminalMonitoringSolution.IServices;
using TerminalMonitoringSolution.Models;
using TerminalMonitoringSolution.Views;

namespace TerminalMonitoringSolution.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class AccountController  : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register (RegistrationDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AccountResponse result = await _accountService.RegisterUser(registerDTO);
            if(!result.Successful)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string token, string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AccountResponse result = await _accountService.ConfirmEmail(token, email);
            if (!result.Successful)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] LoginModel loginCred)
        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }

            var result = await _accountService.Login(loginCred);
            if (!result.Successful)
                return BadRequest(result);

            return Ok(result);
        }

        //Utility Endpoint
        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _accountService.CreateRole(roleName);
            return Ok();
        }
    }
}
