using Dollibar.Cllient.Dtos.StatusDto;
using Dollibar.Cllient.Services.Interfaces;
using Newtonsoft.Json;

namespace Dollibar.Cllient.Services
{
    public class StatusService : IStatusService
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public StatusService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<StatusResponseDto> GetStatus()
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            HttpResponseMessage response = await client.GetAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/status");

            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<StatusResponseDto>(responseBody);
            }
            else
            {
                throw new Exception(responseBody);
            }
        }
    }
}

