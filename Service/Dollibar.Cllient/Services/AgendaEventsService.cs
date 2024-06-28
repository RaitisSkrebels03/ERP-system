using Dollibar.Cllient.Dtos.AgendaEventDto;
using Dollibar.Cllient.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Dollibar.Cllient.Services
{
    public class AgendaEventsService : IAgendaEventsService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AgendaEventsService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<AgendaEventDto>> GetAgendaEvents(string sortfield = "t.id", string sortorder = "ASC", long limit = 100,
                                                      long? page = null, string? user_ids = null, string? sqlFilters = null)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            HttpResponseMessage response = await client.GetAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/agendaevents?sortfield={sortfield}" +
                                                                 $"&sortorder={sortorder}&limit={limit}&page={page}&user_ids={user_ids}&sqlfilters={sqlFilters}");

            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<AgendaEventDto>>(responseBody);
            }
            else
            {
                throw new Exception(responseBody);
            }
        }

        public async Task<AgendaEventDto> GetAgendaEvent(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            HttpResponseMessage response = await client.GetAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/agendaevents/{id}");

            var responseBody = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<AgendaEventDto>(responseBody);
            }
            else
            {
                throw new Exception(responseBody);
            }
        }

        public async Task<string> CreateAgendaEvent(AgendaEventDto agendaEvent)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            JsonContent content = JsonContent.Create(agendaEvent);

            HttpResponseMessage response = await client.PostAsync("http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/agendaevents", content);

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

        public async Task<AgendaEventDto> UpdateAgendaEvent(int id, AgendaEventDto agendaEvent)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            JsonContent content = JsonContent.Create(agendaEvent);

            HttpResponseMessage response = await client.PutAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/agendaevents/{id}", content);

            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<AgendaEventDto>(responseBody);
            }
            else
            {
                throw new Exception(responseBody);
            }
        }

        public async Task<string> DeleteAgendaEvent(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            HttpResponseMessage response = await client.DeleteAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/agendaevents/{id}");

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
