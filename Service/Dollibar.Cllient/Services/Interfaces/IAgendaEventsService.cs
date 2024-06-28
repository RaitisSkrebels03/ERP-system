using Dollibar.Cllient.Dtos.AgendaEventDto;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface IAgendaEventsService
    {
        Task<List<AgendaEventDto>> GetAgendaEvents(string sortfield = "t.id", string sortorder = "ASC", long limit = 100,
                                              long? page = null, string? user_ids = null, string? sqlFilters = null);

        Task<AgendaEventDto> GetAgendaEvent(int id);

        Task<string> CreateAgendaEvent(AgendaEventDto agendaEvent);

        Task<AgendaEventDto> UpdateAgendaEvent(int id, AgendaEventDto agendaEvent);

        Task<string> DeleteAgendaEvent(int id);
    }
}
