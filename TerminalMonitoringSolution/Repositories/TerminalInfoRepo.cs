using System.Runtime.CompilerServices;
using TerminalMonitoringSolution.DataAccess;
using TerminalMonitoringSolution.IRepositories;
using TerminalMonitoringSolution.Migrations.ApplicationDb;
using TerminalMonitoringSolution.Models;
using TerminalMonitoringSolution.Views;

namespace TerminalMonitoringSolution.Repositories
{
    public class TerminalInfoRepo : ITerminalInfoRepo
    {
        private readonly ApplicationDbContext _terminalInfoContext;
        public TerminalInfoRepo(ApplicationDbContext terminalInfoContext)
        {
            _terminalInfoContext = terminalInfoContext;
        }

        public async Task<bool> Post(TerminalInfo terminalInfoDetatils)
        {
            try
            {
                await _terminalInfoContext.AddAsync(terminalInfoDetatils);
                await _terminalInfoContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<TerminalInfo?> Get(string terminalId)
        {

            TerminalInfo? response = _terminalInfoContext.TerminalInformation.Where(ti => ti.TerminalId == terminalId)
                                                                                    .OrderByDescending(ti => ti.TimeCreated)
                                                                                    .FirstOrDefault();
            return response;
        }
    }
}
