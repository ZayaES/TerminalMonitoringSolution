using Microsoft.IdentityModel.Tokens;
using TerminalMonitoringSolution.Entity;
using TerminalMonitoringSolution.IRepositories;
using TerminalMonitoringSolution.IServices;
using TerminalMonitoringSolution.Models;
using TerminalMonitoringSolution.Views;

namespace TerminalMonitoringSolution.Services
{
    public class TerminalService : ITerminalService
    {
        private readonly ITerminalRepo _terminalRepo;
        private readonly ISerialNumberService _serialNumberService;
        private readonly IIPAddressService _ipAddressService;

        public TerminalService(ITerminalRepo terminalRepo, ISerialNumberService serialNumberService, IIPAddressService ipAddressService)
        {
            _terminalRepo = terminalRepo;
            _serialNumberService = serialNumberService;
            _ipAddressService = ipAddressService;
        }
        public async Task<TerminalResponse> Post(TerminalModel terminalDataDetails)
        {
            try
            {
                // Change this to terminal Model version

                TerminalInfo newTermInfo = new TerminalInfo
                {
                    Id = _serialNumberService.GetNextSerialId("TerminalInformation"),
                    TerminalId = terminalDataDetails.TerminalId,
                    TimeCreated = terminalDataDetails.TimeCreated,
                    Signal = terminalDataDetails.Signal,
                    LocationExact = terminalDataDetails.Location,
                    BatteryLevel = terminalDataDetails.BatteryLevel,
                    IpAddress = terminalDataDetails.IpAddress,
                };

                if(newTermInfo.IpAddress.IsNullOrEmpty())
                {
                    newTermInfo.IpAddress = _ipAddressService.GetUserIpAddress();
                }

                newTermInfo.LocationApprox = await _ipAddressService.GetLocationApprox(newTermInfo.IpAddress);
                


                bool staus = await _termInfoRepo.Post(newTermInfo);
                if (!staus)
                {
                    return new TerminalResponse
                    {
                        Successful = false,
                        ErrorMessage = "Error occured. Check that Check that the terminalId is valid"
                    };
                }
                    
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
            Terminal response;
            try
            {
                response = await _terminalRepo.Get(terminalId);
                if(response == null)
                {
                    return new TerminalResponse() { Successful = false, ErrorMessage = "TerminalId does not exist or Terminal has no information" };
                }
                TerminalModel actResponse = new TerminalModel
                {
                    Id = response.Id,
                    CustodianId = response.CustodianId,
                    CustodianName = response.Custodian.Name.ToString(),
                    Region = response.Region,
                    DateAssigned = response.DateAssigned,
                    TerminalStatus = response.TerminalInfo.FirstOrDefault().Signal,
                };

                TerminalResponse result = new TerminalResponse()
                {
                    Terminals = new List<TerminalModel>
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
