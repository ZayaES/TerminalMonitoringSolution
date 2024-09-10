
using static TerminalMonitoringSolution.Models.TransactionDTO;
using TerminalMonitoringSolution.Views;

namespace TerminalMonitoringSolution.IServices
{
    public interface ITransactionService
    {
        Task<TransactionResponse> GetAllTransactions(TxnDTO txn);
    }
}
