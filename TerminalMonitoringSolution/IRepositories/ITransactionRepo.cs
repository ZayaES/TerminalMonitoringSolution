using TerminalMonitoringSolution.Views;
using static TerminalMonitoringSolution.Models.TransactionDTO;

namespace TerminalMonitoringSolution.IRepositories
{
    public interface ITransactionRepo
    {
        Task<TransactionResponse> GetAllTransactions(TxnDTO txn);
    }
}
