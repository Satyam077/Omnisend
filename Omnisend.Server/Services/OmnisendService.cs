using Omnisend.Server.Models;

namespace Omnisend.Server.Services
{
    public class OmnisendService
    {
        private readonly HttpClient _httpClient;
        private readonly OmnisendConfig _config;

        public OmnisendService(HttpClient httpClient, OmnisendConfig config)
        {
            _httpClient = httpClient;
            _config = config;
            _httpClient.BaseAddress = new Uri(_config.BaseUrl);
            _httpClient.DefaultRequestHeaders.Add("X-API-KEY", _config.ApiKey);
        }

        public async Task<(bool ok, string message)> SendStartedCheckoutAsync(StartedCheckoutEventModel model)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("events", model);
                var body = await response.Content.ReadAsStringAsync();
                return (response.IsSuccessStatusCode, body);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
