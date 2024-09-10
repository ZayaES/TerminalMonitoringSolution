using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TerminalMonitoringSolution.IServices;
using TerminalMonitoringSolution.Models;
using TerminalMonitoringSolution.Views;

namespace TerminalMonitoringSolution.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TerminalInfoController : ControllerBase
    {
        private readonly ITerminalService _terminalInfoService;

        public TerminalInfoController(ITerminalService terminalInfoService)
        {
            _terminalInfoService = terminalInfoService;
        }
        [HttpPost]
        public async Task<IActionResult> PostTerminalData(TerminalInfoModel terminalInfo)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TerminalResponse result = await _terminalInfoService.Post(terminalInfo);
            if(!result.Successful)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("{terminalId}")]
        public async Task<IActionResult> GetTerminamData([FromRoute] string terminalId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TerminalResponse result = await _terminalInfoService.Get(terminalId);

            return Ok(result);
        }
    }
}
