using TerminalMonitoringSolution.Entity;
using TerminalMonitoringSolution.Models;

namespace TerminalMonitoringSolution.IRepositories
{
    public interface ITerminalRepo
    {
        Task<bool> Post(Terminal terminalInfoDetails);
        Task<Terminal> Get(string primaryIdentifier);
    }
}
