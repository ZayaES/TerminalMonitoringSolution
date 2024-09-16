using TerminalMonitoringSolution.Entities;
using TerminalMonitoringSolution.Views;
using static TerminalMonitoringSolution.Models.TransactionDTO;

namespace TerminalMonitoringSolution.IRepositories
{
    public interface ITransactionRepo
    {
        Task<TransactionResponse> GetAllTransactions(TxnDTO txn);
        Task<TransactionResponse> PostTransaction(Transaction txn);
    }
}
