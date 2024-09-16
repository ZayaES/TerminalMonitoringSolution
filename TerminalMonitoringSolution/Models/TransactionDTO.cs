using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
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

        public class TerminalTxnDTO
        {
            [Required]
            public required string TerminalId { get; set; }

            [Required]
            public DateTime Time { get; set; }

            [Required]
            public string TransactionReference { get; set; } = string.Empty;

            [Required]
            public decimal Amount { get; set; }

            [Required]
            public TransactionType TransactionType { get; set; }

            [Required]
            private string _transactionDetails;

            [Required]
            public string TransactionDetails
            {
                get
                {
                    return _transactionDetails;
                }
                set
                {
                    if (TransactionType == TransactionType.Withdrawal)
                    {
                        if (value.ToCharArray().Length == 10)
                        {
                            _transactionDetails = value.ToString();
                        }
                    }
                    else if (TransactionType  == TransactionType.Deposit)
                    {
                        if(value.ToCharArray().Length == 10 && int.TryParse(value, out int num))
                        { 
                            _transactionDetails = value.ToString(); 
                        }
                    }
                    else if (TransactionType == TransactionType.Transfer)
                    {
                        var accounts = value.Split(" || ");
                        var half00 = accounts[0].ToCharArray()[0..5];
                        var half01 = accounts[0].ToCharArray()[5..^0];
                        var half10 = accounts[1].ToCharArray()[5..^0];
                        var half11 = accounts[1].ToCharArray()[0..5];

                        if ((accounts[0].ToCharArray().Length == 10 
                            && int.TryParse(half00, out int num3)
                            &&  int.TryParse(half01, out int num4))
                                && (accounts[1].ToCharArray().Length == 10 && int.TryParse(half11, out int num2) && int.TryParse(half10, out int num)))
                        {
                            _transactionDetails = value.ToString();
                        }
                    }
                    else if (TransactionType == TransactionType.Bills)
                    {
                        string[] details = value.Split(":");
                        if (details[0].ToCharArray().Length == 10 && int.TryParse(details[0], out int num))
                        {
                            _transactionDetails = value.ToString();
                        }
                    }
                }
            }

        }

        public class WithdrawalModel
        {
            public string SenderAccount { get; set; }
            public string RecepientAccount { get; set; }
        }
    }
}
