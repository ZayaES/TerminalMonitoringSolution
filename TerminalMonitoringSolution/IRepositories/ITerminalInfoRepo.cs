using TerminalMonitoringSolution.Models;

namespace TerminalMonitoringSolution.IRepositories
{
    public interface ITerminalInfoRepo
    {
        Task Post(TerminalInfo terminalInfoDetails);
        Task<TerminalInfo> Get(string primaryIdentifier);
    }
}
