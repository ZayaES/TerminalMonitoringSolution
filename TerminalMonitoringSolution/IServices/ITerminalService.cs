using TerminalMonitoringSolution.Models;
using TerminalMonitoringSolution.Views;

namespace TerminalMonitoringSolution.IServices
{
    public interface ITerminalService
    {
        Task<TerminalResponse> Post(TerminalInfoModel terminalDataDetails);
        Task<TerminalResponse> Get(string terminalId);
    }
}
