using Dollibar.Cllient.Dtos.TicketDto;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface ITicketsService
    {
        Task<List<TicketDto>> GetTickets(long? socid = null, string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100, long? page = null, string? sqlfilters = null);
        Task<TicketDto> GetTicket(int id);
        Task<TicketDto> GetTicketByRef(string @ref);
        Task<TicketDto> GetTicketByTrackId(string track_id);
        Task<string> CreateTickets(TicketDto tickets);
        Task<TicketDto> UpdateTickets(int id, TicketDto tickets);
        Task<string> DeleteTickets(int id);

    }
}
