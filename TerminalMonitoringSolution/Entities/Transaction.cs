using System.Data;
using TerminalMonitoringSolution.Entity;

namespace TerminalMonitoringSolution.Entities
{
    public class Transaction
    {
        public string Id { get; set; } = string.Empty;
        public DateTime DateLogged {  get; set; }
        public string TransactionReference { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string TerminalId { get; set; } = string.Empty;
        private decimal custodianShare;
        public decimal CustodianShare 
        { 
            set
            {
                custodianShare = value;
            }
        }
        private decimal bankShare;
        public decimal BankShare
        {
            set
            {
                bankShare = value;
            }
        }
        public Terminal Terminal { get; set; }
    }
}

/* "Date Logged": "09-Nov-2023 00:00",
  "Agent Name": "OSENI KUDIRAT",
  "Agent Network Manager": "OGBA",
  "Cluster Code": 132,
  "Agent Cluster Manager": "OLUWASEUN OMOTOSO",
  "Agent Category": "ISW-ENABLED POLARIS AGENTS",
  "Terminal ID": "2076IA97",
  "Transaction Reference": "2076IA97-101191924865-8000-09112023 05:47",
  "Agent Phone Number": "07030721233",
  "Transaction Amount": 8000,
  "Agent Share": "7,960.00",
  "Bank Share": "18.60",
  "Appzone Share": "18.61",
  "Region": "LAGOS"
*/