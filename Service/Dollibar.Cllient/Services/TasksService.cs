using Dollibar.Cllient.Dtos.TaskDto;
using Dollibar.Cllient.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Dollibar.Cllient.Services
{
    public class TasksService : ITasksService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TasksService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<TaskDto>> GetTasks(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                                  long? page = null, string? sqlFilters = null)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            HttpResponseMessage response = await client.GetAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/tasks?sortfield={sortfield}" +
                                                                 $"&sortorder={sortorder}&limit={limit}&page={page}&sqlfilters={sqlFilters}");

            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<TaskDto>>(responseBody);
            }
            else
            {
                throw new Exception(responseBody);
            }
        }

        public async Task<TaskDto> GetTask(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            HttpResponseMessage response = await client.GetAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/tasks/{id}");

            var responseBody = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TaskDto>(responseBody);
            }
            else
            {
                throw new Exception(responseBody);
            }
        }

        public async Task<string> CreateTask(TaskDto task)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            JsonContent content = JsonContent.Create(task);

            HttpResponseMessage response = await client.PostAsync("http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/tasks", content);

            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return responseBody;
            }
            else
            {
                throw new Exception(responseBody);
            }
        }


        public async Task<TaskDto> UpdateTask(int id, TaskDto task)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            JsonContent content = JsonContent.Create(task);

            HttpResponseMessage response = await client.PutAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/tasks/{id}", content);

            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TaskDto>(responseBody);
            }
            else
            {
                throw new Exception(responseBody);
            }
        }

        public async Task<string> DeleteTask(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            HttpResponseMessage response = await client.DeleteAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/tasks/{id}");

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
