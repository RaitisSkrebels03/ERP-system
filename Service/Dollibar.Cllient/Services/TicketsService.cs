using Dollibar.Cllient.Dtos.TicketDto;
using Dollibar.Cllient.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Diagnostics;

namespace Dollibar.Cllient.Services
{
    public class TicketsService : ITicketsService
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public TicketsService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<TicketDto>> GetTickets(long? socid = null, string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100, long? page = null, string? sqlfilters = null)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            HttpResponseMessage response = await client.GetAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/tickets?socid={socid}&sortfield={sortfield}&sortorder={sortorder}&limit={limit}&page={page}&sqlfilters={sqlfilters}");

            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<TicketDto>>(responseBody);
            }
            else
            {
                throw new Exception(responseBody);
            }
        }

        public async Task<TicketDto> GetTicket(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            HttpResponseMessage response = await client.GetAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/tickets/{id}");

            var responseBody = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TicketDto>(responseBody);
            }
            else
            {
                throw new Exception(responseBody);
            }
        }

        public async Task<TicketDto> GetTicketByRef(string @ref)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            HttpResponseMessage response = await client.GetAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/tickets/ref/{@ref}");

            var responseBody = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TicketDto>(responseBody);
            }
            else
            {
                throw new Exception(responseBody);
            }
        }

        public async Task<TicketDto> GetTicketByTrackId(string track_id)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            HttpResponseMessage response = await client.GetAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/tickets/track_id/{track_id}");

            var responseBody = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TicketDto>(responseBody);
            }
            else
            {
                throw new Exception(responseBody);
            }
        }

        public async Task<string> CreateTickets(TicketDto tickets)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            JsonContent content = JsonContent.Create(tickets);

            HttpResponseMessage response = await client.PostAsync("http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/tickets", content);

            string responseBody = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(responseBody);

            if (response.IsSuccessStatusCode)
            {
                return responseBody;
            }
            else
            {
                throw new Exception(responseBody);
            }
        }

        public async Task<TicketDto> UpdateTickets(int id, TicketDto ticket)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            JsonContent content = JsonContent.Create(ticket);

            HttpResponseMessage response = await client.PutAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/tickets/{id}", content);

            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TicketDto>(responseBody);
            }
            else
            {
                throw new Exception(responseBody);
            }
        }

        public async Task<string> DeleteTickets(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("DOLAPIKEY", Token.DOLAPIKEY);

            HttpResponseMessage response = await client.DeleteAsync($"http://ec2-51-20-142-167.eu-north-1.compute.amazonaws.com/api/index.php/tickets/{id}");

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

