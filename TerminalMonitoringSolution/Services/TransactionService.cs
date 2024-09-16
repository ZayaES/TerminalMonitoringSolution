using TerminalMonitoringSolution.Entities;
using TerminalMonitoringSolution.IRepositories;
using TerminalMonitoringSolution.IServices;
using TerminalMonitoringSolution.Views;
using static TerminalMonitoringSolution.Models.Enums;
using static TerminalMonitoringSolution.Models.TransactionDTO;

namespace TerminalMonitoringSolution.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepo _transactionAccessor;
        private readonly ISerialNumberService _serialNumberService;

        public TransactionService(ITransactionRepo transactionAccessor, ISerialNumberService serialNumberService)
        {
            _transactionAccessor = transactionAccessor;
            _serialNumberService = serialNumberService;
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

        public async Task<TransactionResponse> PostTransaction(TerminalTxnDTO txn)
        {
            Transaction transaction = new Transaction()
            {
                Id = _serialNumberService.GetNextSerialId("Transactions"),
                TimeLogged = DateTime.Now,
                TransactionTime = txn.Time,
                TransactionReference = txn.TransactionReference,
                Amount = txn.Amount,
                TerminalId = txn.TerminalId,
                TransactionType = txn.TransactionType,
                TransactionDetails = txn.TransactionDetails,
            };

            var result = await _transactionAccessor.PostTransaction(transaction);
            return result;
        }
    }
}
