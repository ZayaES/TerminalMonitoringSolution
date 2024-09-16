using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin")]
        [HttpGet("{terminalId}")]
        public async Task<IActionResult> GetTerminamData([FromRoute] string terminalId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TerminalResponse result = await _terminalInfoService.Get(terminalId);
            if (!result.Successful)
            {
                if (result.ErrorMessage == "TerminalId does not exist or Terminal has no information")
                {
                    return NotFound(result);
                }
                return BadRequest(result);
            }

            return Ok(result);
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
                if(result.ErrorMessage != "Error occured. Check that Check that the terminalId is valid")
                    result.ErrorMessage = "Some unknown error occured while posting data";
                return BadRequest(result);
            }

            return Ok(result);
        }

        
    }
}
