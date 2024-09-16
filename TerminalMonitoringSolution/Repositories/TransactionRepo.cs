using Microsoft.EntityFrameworkCore;
using TerminalMonitoringSolution.DataAccess;
using TerminalMonitoringSolution.Entities;
using TerminalMonitoringSolution.IRepositories;
using TerminalMonitoringSolution.Views;
using static TerminalMonitoringSolution.Models.Enums;
using static TerminalMonitoringSolution.Models.TransactionDTO;

namespace TerminalMonitoringSolution.Repositories
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly ApplicationDbContext _applicationAccessor;
        public TransactionRepo(ApplicationDbContext applicationAccessor) 
        {
            _applicationAccessor = applicationAccessor;
        }
        public async Task<TransactionResponse> GetAllTransactions(TxnDTO txn)
        {
            TransactionResponse response = new TransactionResponse();
            List<Transaction> transactions;
            try {
                switch (txn.SearchParam)
                {
                    case TxnSearchEnum.TransactionReference:
                        transactions = await _applicationAccessor.Transactions.Where(trn => trn.TransactionReference == txn.SearchValue)
                                                                            .Skip((int)txn.Offset)
                                                                            .Take((int)txn.Count)
                                                                            .ToListAsync();
                        break;

                    case TxnSearchEnum.TerminalId:
                        transactions = await _applicationAccessor.Transactions.Where(trn => trn.TerminalId == txn.SearchValue)
                                                                            .Skip((int)txn.Offset)
                                                                            .Take((int)txn.Count)
                                                                            .ToListAsync();
                        break;

                    default:
                        throw new Exception("Search Parameter Invalid");
                }


                response.Successful = true;
                response.Transactions = transactions;

                return response;
            }
            catch (Exception ex)
            {
                response.Successful = false;
                response.ErrorMessage = ex.Message;

                return response;
            }
        }

        public async Task<TransactionResponse> PostTransaction(Transaction txn)
        {
            TransactionResponse response = new TransactionResponse();
            try
            {
                var result = await _applicationAccessor.Transactions.AddAsync(txn);
                if (result.State != EntityState.Added)
                {
                    response.Successful = false;
                    response.ErrorMessage = "Unable to add Transaction";
                }

                await _applicationAccessor.SaveChangesAsync();
                response.Successful = true;
                return response;
            }
            catch
            {
                return response;
            }
            
        }
    }
}
