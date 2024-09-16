namespace TerminalMonitoringSolution.IServices
{
    public interface IIPAddressService
    {
        Task<string> GetLocationApprox(string ipAddress);
        string GetUserIpAddress();
    }
}