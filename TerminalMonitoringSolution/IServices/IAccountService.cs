using TerminalMonitoringSolution.Models;
using TerminalMonitoringSolution.Views;

namespace TerminalMonitoringSolution.IServices
{
    public interface IAccountService
    {
        Task<AccountResponse> RegisterUser(RegistrationDTO userRegDTO);
        Task<AccountResponse> ConfirmEmail(string token, string email);
        Task<AccountResponse> Login(LoginModel loginCred);
        Task CreateRole(string roleName);
    }
}
