using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using TerminalMonitoringSolution.DataAccess;

namespace TerminalMonitoringSolution.Models
{
    public class RegistrationDTO
    {
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public bool IsSuperAdmin { get; set; }
    }

}
