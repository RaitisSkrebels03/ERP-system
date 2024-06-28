using Dollibar.Cllient.Dtos.LoginDto;
using Dollibar.Cllient.Services.Interfaces;
using Newtonsoft.Json;

namespace Dollibar.Cllient.Services
{
    public class LoginService : ILoginService
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public LoginService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<LoginResponseDto> Login(string login, string password, string? entity = null, int reset = 0)
        {
            // Create a named client or use the default client
            HttpClient client = _httpClientFactory.CreateClient();

            // Make an HTTP GET request
            HttpResponseMessage response = await client.GetAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/login?login={login}&password={password}&entity={entity}&reset={reset}");

            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                LoginResponseDto successResponse = JsonConvert.DeserializeObject<LoginResponseDto>(responseBody);
                Token.DOLAPIKEY = successResponse.Success.Token;
                return successResponse;
            }
            else
            {
                // Handle error
                throw new Exception(responseBody);
            }
        }
    }
}
