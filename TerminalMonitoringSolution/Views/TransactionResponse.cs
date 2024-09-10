
using TerminalMonitoringSolution.Entities;

namespace TerminalMonitoringSolution.Views
{
    public class TransactionResponse
    {
        public List<Transaction>? Transactions { get; set; }
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
