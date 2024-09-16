using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Policy = "RequiresSuperAdmin")]
        [HttpGet("Get")]
        public async Task<IActionResult> Transactions([FromQuery] TxnDTO txn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);               
            }

            var response = await _transactions.GetAllTransactions(txn);
            return Ok(response);
        }


        [HttpPost("Post")]
        public async Task<IActionResult> Transactions([FromBody] TerminalTxnDTO custodianTxn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _transactions.PostTransaction(custodianTxn);
            return Ok(response);
        }
    }
}
