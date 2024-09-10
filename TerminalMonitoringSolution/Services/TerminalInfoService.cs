using TerminalMonitoringSolution.IRepositories;
using TerminalMonitoringSolution.IServices;
using TerminalMonitoringSolution.Models;
using TerminalMonitoringSolution.Views;

namespace TerminalMonitoringSolution.Services
{
    public class TerminalInfoService : ITerminalService
    {
        private readonly ITerminalInfoRepo _termInfoRepo;

        public TerminalInfoService(ITerminalInfoRepo termInfoRepo)
        {
            _termInfoRepo = termInfoRepo;
        }
        public async Task<TerminalResponse> Post(TerminalInfoModel terminalDataDetails)
        {
            try
            {
                TerminalInfo newTermInfo = new TerminalInfo
                {
                    TerminalId = terminalDataDetails.TerminalId,
                    TimeCreated = terminalDataDetails.TimeCreated,
                    Signal = terminalDataDetails.Signal,
                    LocationExact = terminalDataDetails.Location,
                    BatteryLevel = terminalDataDetails.BatteryLevel,
                    IpAddress = terminalDataDetails.IpAddress,

                };
                await _termInfoRepo.Post(newTermInfo);
            }
            catch (Exception ex)
            {
                return new TerminalResponse 
                { 
                    Successful = false,
                    ErrorMessage = ex.Message,
                };
            }
            return new TerminalResponse { Successful = true };
        }

        public async Task<TerminalResponse> Get(string terminalId)
        {
            TerminalInfo response;
            try
            {
                response = await _termInfoRepo.Get(terminalId);
                TerminalInfoModel actResponse = new TerminalInfoModel
                {
                    TerminalId = response.TerminalId,
                    TimeCreated = response.TimeCreated,
                    Signal = response.Signal,
                    Location = response.LocationExact ?? response.LocationApprox,
                    BatteryLevel = response.BatteryLevel,
                    IpAddress = response.IpAddress,

                };

                TerminalResponse result = new TerminalResponse()
                {
                    TerminalData = new List<TerminalInfoModel>
                    {
                        actResponse,
                    },
                    Successful = true,
                };
                return result;
            }
            catch (Exception ex)
            {
                return new TerminalResponse() { Successful = false, ErrorMessage = ex.Message, };
            }

            
        }
    }
}
