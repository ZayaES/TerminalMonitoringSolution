using TerminalMonitoringSolution.DataAccess;
using TerminalMonitoringSolution.Entity;
using TerminalMonitoringSolution.IRepositories;

namespace TerminalMonitoringSolution.Repositories
{
    public class TerminalRepo : ITerminalRepo
    {
        private readonly ApplicationDbContext _terminalContext;

        public TerminalRepo(ApplicationDbContext terminalContext)
        {
            _terminalContext = terminalContext;
        }

        public Task<Terminal> Get(string terminalId)
        {

        }

        public Task<bool> Post(Terminal terminal)
        {

        }
    }
}
