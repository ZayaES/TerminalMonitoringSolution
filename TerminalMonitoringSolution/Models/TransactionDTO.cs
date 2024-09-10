using System.Transactions;
using static TerminalMonitoringSolution.Models.Enums;

namespace TerminalMonitoringSolution.Models
{
    public class TransactionDTO
    {
        public class TxnDTO
        {
            public uint Count { get; set; } = 10;
            public uint Offset { get; set; } = 0;
            public TxnSearchEnum? SearchParam { get; set; }
            public string? SearchValue { get; set; }
        }

        public class CustodianTxnDTO : TxnDTO
        {
            public required string Id { get; set; }
        }
    }
}
