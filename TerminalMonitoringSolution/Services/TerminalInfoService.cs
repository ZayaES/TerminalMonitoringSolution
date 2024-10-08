﻿using Microsoft.IdentityModel.Tokens;
using TerminalMonitoringSolution.IRepositories;
using TerminalMonitoringSolution.IServices;
using TerminalMonitoringSolution.Models;
using TerminalMonitoringSolution.Views;

namespace TerminalMonitoringSolution.Services
{
    public class TerminalInfoService : ITerminalService
    {
        private readonly ITerminalInfoRepo _termInfoRepo;
        private readonly ISerialNumberService _serialNumberService;
        private readonly IIPAddressService _ipAddressService;

        public TerminalInfoService(ITerminalInfoRepo termInfoRepo, ISerialNumberService serialNumberService, IIPAddressService ipAddressService)
        {
            _termInfoRepo = termInfoRepo;
            _serialNumberService = serialNumberService;
            _ipAddressService = ipAddressService;
        }
        public async Task<TerminalResponse> Post(TerminalInfoModel terminalDataDetails)
        {
            try
            {
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
            TerminalInfo response;
            try
            {
                response = await _termInfoRepo.Get(terminalId);
                if(response == null)
                {
                    return new TerminalResponse() { Successful = false, ErrorMessage = "TerminalId does not exist or Terminal has no information" };
                }
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
