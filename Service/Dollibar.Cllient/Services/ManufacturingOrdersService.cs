using Dollibar.Cllient.Dtos.ManufacturingOrderDto;
using Dollibar.Cllient.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Dollibar.Cllient.Services
{
    public class ManufacturingOrdersService : IManufacturingOrdersService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ManufacturingOrdersService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<ManufacturingOrderDto>> GetManufacturingOrders(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                                                              long? page = null, string? sqlfilters = null)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            HttpResponseMessage response = await client.GetAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/mos?sortfield={sortfield}" +
                                                                 $"&sortorder={sortorder}&limit={limit}&page={page}&sqlfilters={sqlfilters}");

            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<ManufacturingOrderDto>>(responseBody);
            }
            else
            {
                throw new Exception(responseBody);
            }
        }

        public async Task<ManufacturingOrderDto> GetManufacturingOrder(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            HttpResponseMessage response = await client.GetAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/mos/{id}");

            var responseBody = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ManufacturingOrderDto>(responseBody);
            }
            else
            {
                throw new Exception(responseBody);
            }
        }

        public async Task<string> CreateManufacturingOrder(ManufacturingOrderDto manufacturingOrder)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            JsonContent content = JsonContent.Create(manufacturingOrder);

            HttpResponseMessage response = await client.PostAsync("http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/mos", content);

            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return responseBody;
            }
            else
            {
                throw new Exception(responseBody);
            }
        }

        public async Task<ManufacturingOrderDto> UpdateManufacturingOrder(int id, ManufacturingOrderDto manufacturingOrder)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            JsonContent content = JsonContent.Create(manufacturingOrder);

            HttpResponseMessage response = await client.PutAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/mos/{id}", content);

            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ManufacturingOrderDto>(responseBody);
            }
            else
            {
                throw new Exception(responseBody);
            }
        }

        public async Task<string> DeleteManufacturingOrder(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            HttpResponseMessage response = await client.DeleteAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/mos/{id}");

            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return responseBody;
            }
            else
            {
                throw new Exception(responseBody);
            }

        }
    }
}
