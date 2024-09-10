using TerminalMonitoringSolution.IRepositories;
using TerminalMonitoringSolution.IServices;
using TerminalMonitoringSolution.Views;
using static TerminalMonitoringSolution.Models.TransactionDTO;

namespace TerminalMonitoringSolution.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepo _transactionAccessor;

        public TransactionService(ITransactionRepo transactionAccessor)
        {
            _transactionAccessor = transactionAccessor;
        }
        public async Task<TransactionResponse> GetAllTransactions(TxnDTO txn)
        {
            TransactionResponse response = new TransactionResponse();

            if (!txn.SearchParam.HasValue && txn.SearchValue != null)
            {
                response.Successful = false;
                response.ErrorMessage = "No parameter for search value";
                return response;
            }
            if (txn.SearchParam.HasValue && txn.SearchValue == null)
            {
                response.Successful = false;
                response.ErrorMessage = "No valid input to search";
                return response;
            }
            var result = await _transactionAccessor.GetAllTransactions(txn);

            response = result;
            return response;
        }
    }
}
