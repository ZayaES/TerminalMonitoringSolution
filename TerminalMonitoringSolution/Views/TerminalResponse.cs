using TerminalMonitoringSolution.Entity;
using TerminalMonitoringSolution.Models;

namespace TerminalMonitoringSolution.Views
{
    public class TerminalResponse
    {
        public List<TerminalInfoModel>? TerminalData { get; set; }
        public List<Terminal>? Terminals { get; set; }
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
