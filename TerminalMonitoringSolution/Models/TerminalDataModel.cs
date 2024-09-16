
using System.ComponentModel.DataAnnotations;
using static TerminalMonitoringSolution.Models.Enums;

namespace TerminalMonitoringSolution.Models
{
    public class TerminalInfoModel
    {
        [Required]
        public required string TerminalId { get; set; } 
        [Required]
        public DateTime TimeCreated { get; set; }
        [Required]
        public SignalEnum Signal { get; set; }

        public string Location { get; set; } = "[ , ]";

        public string IpAddress { get; set; } = string.Empty;

        [Required]
        public string BatteryLevel { get; set; } = string.Empty;
    }
}
