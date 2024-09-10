using TerminalMonitoringSolution.DataAccess;
using TerminalMonitoringSolution.Models;

namespace TerminalMonitoringSolution.Views
{
    public class AccountResponse
    {
        public List<AdminDTO>? Admin { get; set; }
        public object? token { get; set; } = string.Empty;
        public bool Successful { get; set; }
        private string? _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage ?? string.Empty;
            }
            set
            {
                if (!this.Successful)
                    this._errorMessage = value;
            }
        }
    }
}
