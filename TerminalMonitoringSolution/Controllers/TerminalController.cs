using Microsoft.AspNetCore.Mvc;
using TerminalMonitoringSolution.IServices;
using TerminalMonitoringSolution.Views;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TerminalMonitoringSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminalController : ControllerBase
    {
        private readonly ITerminalService _terminalService;

        public TerminalController(ITerminalService terminalService)
        {
            _terminalService = terminalService;
        }
        // GET: api/<TerminalController>
        [HttpGet]
        public async Task<IActionResult> Get(string terminalId)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TerminalResponse response = await _terminalService.Get(terminalId);
            if (response.Successful == false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        // GET api/<TerminalController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TerminalController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TerminalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TerminalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
