using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using TerminalMonitoringSolution.IRepositories;
using TerminalMonitoringSolution.IServices;
using TerminalMonitoringSolution.Services;
using static TerminalMonitoringSolution.Models.TransactionDTO;

namespace TerminalMonitoringSolution.Controllers
{

    [ApiController]
    [Route("api/v1/[Controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactions;
        public TransactionController(ITransactionService transactions) 
        {
            _transactions = transactions;
        }

        [HttpGet]
        public async Task<IActionResult> Transactions([FromQuery] TxnDTO txn)
        {
            return Ok(await _transactions.GetAllTransactions(txn));
        }

        [HttpPost]

        public async Task<IActionResult> Transactions([FromQuery] CustodianTxnDTO custodianTxn)
        {
            return Ok();
        }
    }
}
