using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using TerminalMonitoringSolution.IServices;

namespace TerminalMonitoringSolution.Services
{
    public class IPAddressService : IIPAddressService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _url;

        public IPAddressService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, HttpClient httpClient)
        {
            _contextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClient = httpClient;
            _apiKey = _configuration["GeoLocation:ApiKey"];
            _url = _configuration["GeoLocation:BaseUrl"];
        }

        public string GetUserIpAddress()
        {
            HttpContext? httpContext = _contextAccessor.HttpContext;
            if (httpContext == null)
                return "";
            IPAddress? ipAddress = httpContext.Connection.RemoteIpAddress;
            if (ipAddress == null)
                return "";

            if (!httpContext.Request.Headers.TryGetValue("X-Forwarded-For", out Microsoft.Extensions.Primitives.StringValues value))
            {
                Console.WriteLine(value);
                return ipAddress.ToString();
            }
            string xForwardedFor = value.ToString();
            string[] addresses = xForwardedFor.Split(',').Select(ip => ip.Trim()).ToArray();

            foreach (string address in addresses)
            {
                if (!IPAddress.TryParse(address, out ipAddress))
                    return "";
                if (!IsPrivateIpAddress(ipAddress))
                {
                    break;
                }
            }
            return ipAddress.ToString();
        }

        private bool IsPrivateIpAddress(IPAddress ipAddress)
        {
            if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                byte[] bytes = ipAddress.GetAddressBytes();
                return (bytes[0] == 10) ||
                       (bytes[0] == 172 && bytes[1] >= 16 && bytes[1] <= 31) ||
                       (bytes[0] == 192 && bytes[1] == 168);
            }
            else if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
            {
                return ipAddress.IsIPv6LinkLocal || ipAddress.IsIPv6SiteLocal;
            }
            return false;
        }

        public async Task<string> GetLocationApprox(string ipAddress)
        {
            if (!IPAddress.TryParse(ipAddress, out IPAddress? _))
                throw new ArgumentException("Input is not an IpAddress");
            string url = $"{_url}{ipAddress}/json?token={_apiKey}";
            string response = await _httpClient.GetStringAsync(url);
            JObject data = JObject.Parse(response);
            Console.WriteLine(data);
            string? region = data["region"]?.ToString();
            string? country = data["country"]?.ToString();
            var loc = data["loc"]?.ToString();
            var city = data["city"]?.ToString();

            return loc ?? $"{region}, {city}, {country}";
        }
    }
}
