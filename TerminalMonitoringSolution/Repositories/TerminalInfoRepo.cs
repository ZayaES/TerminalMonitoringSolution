using System.Runtime.CompilerServices;
using TerminalMonitoringSolution.DataAccess;
using TerminalMonitoringSolution.IRepositories;
using TerminalMonitoringSolution.Models;

namespace TerminalMonitoringSolution.Repositories
{
    public class TerminalInfoRepo : ITerminalInfoRepo
    {
        private readonly ApplicationDbContext _terminalInfoContext;
        public TerminalInfoRepo(ApplicationDbContext terminalInfoContext)
        {
            _terminalInfoContext = terminalInfoContext;
        }

        public async Task Post(TerminalInfo terminalInfoDetatils)
        {
            await _terminalInfoContext.AddAsync(terminalInfoDetatils);
            await _terminalInfoContext.SaveChangesAsync();
        }

        public async Task<TerminalInfo> Get(string primaryIdentifier)
        {
            // There will be many terminalInfo for one terminalId, hence i need to get the last one. This is what to implement next
            TerminalInfo? response = await _terminalInfoContext.TerminalInformation.FindAsync(primaryIdentifier);
            return response ?? new TerminalInfo { };
        }
    }
}
