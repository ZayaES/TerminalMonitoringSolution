using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using TerminalMonitoringSolution.Entities;
using TerminalMonitoringSolution.Models;
using static TerminalMonitoringSolution.Models.Enums;

namespace TerminalMonitoringSolution.Entity
{
    public class Terminal
    {
        public string Id { get; set; } = string.Empty;
        public string  CustodianId {  get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public DateTime DateAssigned { get; set; }
        public Custodian? Custodian { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
        public ICollection<TerminalInfo>? TerminalInfo { get; set; }
    }
}