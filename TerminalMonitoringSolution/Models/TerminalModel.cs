using TerminalMonitoringSolution.Entities;
using static TerminalMonitoringSolution.Models.Enums;

namespace TerminalMonitoringSolution.Models
{
    public class TerminalModel
    {
        public string Id { get; set; } = string.Empty;
        public string CustodianId { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public DateTime DateAssigned { get; set; }
        public string CustodianName { get; set; } = string.Empty;
        public ICollection<Transaction>? Transactions { get; set; }
        public SignalEnum TerminalStatus { get; set; }
    }
}
