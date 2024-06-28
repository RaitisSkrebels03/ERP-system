using Dollibar.Cllient.Dtos.AgendaEventDto;
using Dollibar.Cllient.Dtos.TaskDto;
using Dollibar.Cllient.Services;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dollibar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendaEventsController
    {
        private readonly IAgendaEventsService _agendaEventsService;

        public AgendaEventsController(IAgendaEventsService agendaEventsService)
        {
            _agendaEventsService = agendaEventsService;
        }

        [HttpGet]
        public async Task<List<AgendaEventDto>> GetAgendaEvents(string sortfield = "t.id", string sortorder = "ASC", long limit = 100,
                                                  long? page = null, string? user_ids = null, string? sqlFilters = null)
        {
            return await _agendaEventsService.GetAgendaEvents(sortfield, sortorder, limit, page, user_ids, sqlFilters);
        }

        [HttpGet("{id:int}")]
        public async Task<AgendaEventDto> GetAgendaEvent(int id)
        {
            return await _agendaEventsService.GetAgendaEvent(id);
        }

        [HttpPost]
        public async Task<string> CreateAgendaEvent(AgendaEventDto agendaEvent)
        {
            return await _agendaEventsService.CreateAgendaEvent(agendaEvent);
        }

        [HttpPut("{id:int}")]
        public async Task<AgendaEventDto> UpdateAgendaEvent(int id, AgendaEventDto agendaEvent)
        {
            return await _agendaEventsService.UpdateAgendaEvent(id, agendaEvent);
        }

        [HttpDelete("{id:int}")]
        public async Task<string> DeleteAgendaEvent(int id)
        {
            return await _agendaEventsService.DeleteAgendaEvent(id);
        }
    }
}
