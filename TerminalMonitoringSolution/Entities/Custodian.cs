using TerminalMonitoringSolution.Entity;
using static TerminalMonitoringSolution.Models.Enums;

namespace TerminalMonitoringSolution.Entities
{
    public class Custodian
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public GenderEnum Gender { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Address {  get; set; } = string.Empty;
        public string LGA { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Cluster { get; set; } = string.Empty;
        public string ClusterCode { get; set; } = string.Empty;
        public string ClusterManager { get; set; } = string.Empty;
        public string ANM {  get; set; } = string.Empty;
        public CustodianType Type { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateActivated { get; set; }
        public StatusEnum Status { get; set; }
        public string IncomeAccount { get; set; } = string.Empty;
        public ICollection<Terminal> Terminals { get; set; }
    }
}
