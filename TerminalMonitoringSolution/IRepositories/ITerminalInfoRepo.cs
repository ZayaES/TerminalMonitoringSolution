using TerminalMonitoringSolution.Models;

namespace TerminalMonitoringSolution.IRepositories
{
    public interface ITerminalInfoRepo
    {
        Task<bool> Post(TerminalInfo terminalInfoDetails);
        Task<TerminalInfo> Get(string primaryIdentifier);
    }
}
