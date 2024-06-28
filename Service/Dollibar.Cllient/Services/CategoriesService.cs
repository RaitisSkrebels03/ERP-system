using Dollibar.API.Dtos;
using Dollibar.Cllient.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Dollibar.Cllient.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoriesService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<CategoryDto>> GetCategories(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                                           long? page = null, string? type = null, string? sqlfilters = null)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            HttpResponseMessage response = await client.GetAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/categories?sortfield={sortfield}" +
                                                                 $"&sortorder={sortorder}&limit={limit}&page={page}&type={type}&sqlfilters={sqlfilters}");

            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<CategoryDto>>(responseBody);
            }
            else
            {
                throw new Exception(responseBody);
            }
        }

        public async Task<CategoryDto> GetCategory(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            HttpResponseMessage response = await client.GetAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/categories/{id}");

            var responseBody = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CategoryDto>(responseBody);
            }
            else
            {
                throw new Exception(responseBody);
            }

        }

        public async Task<string> CreateCategory(CategoryDto category)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            JsonContent content = JsonContent.Create(category);

            HttpResponseMessage response = await client.PostAsync("http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/categories", content);

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


        public async Task<CategoryDto> UpdateCategory(int id, CategoryDto category)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            JsonContent content = JsonContent.Create(category);

            HttpResponseMessage response = await client.PutAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/categories/{id}", content);

            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CategoryDto>(responseBody);
            }
            else
            {
                // Handle error
                throw new Exception(responseBody);
            }
        }

        public async Task<string> DeleteCategory(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            HttpResponseMessage response = await client.DeleteAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/categories/{id}");

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
