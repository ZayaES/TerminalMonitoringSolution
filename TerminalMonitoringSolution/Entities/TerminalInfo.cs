
using TerminalMonitoringSolution.Entity;
using static TerminalMonitoringSolution.Models.Enums;

namespace TerminalMonitoringSolution.Models
{
    public class TerminalInfo
    {
        public string Id { get; set; }
        public DateTime TimeCreated { get; set; }
        public SignalEnum Signal { get; set; }
        public string LocationExact { get; set; } = "[ , ]";
        public string LocationApprox { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
        public string TerminalId { get; set; } = string.Empty;
        public Terminal? Terminal { get; set; }
        public string BatteryLevel { get; set; } = string.Empty;
    }
}
