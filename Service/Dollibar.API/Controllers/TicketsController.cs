using Dollibar.Cllient.Dtos.TicketDto;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dollibar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsService _ticketsService;

        public TicketsController(ITicketsService ticketsService)
        {
            _ticketsService = ticketsService;
        }

        [HttpGet]
        public async Task<List<TicketDto>> GetTickets(long? socid = null, string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100, long? page = null, string? sqlfilters = null)
        {
            return await _ticketsService.GetTickets(socid, sortfield, sortorder, limit, page, sqlfilters);
        }

        [HttpGet("{id:int}")]
        public async Task<TicketDto> GetTicket(int id)
        {
            return await _ticketsService.GetTicket(id);
        }

        [HttpPost]
        public async Task<string> CreateTickets(TicketDto ticket)
        {
            return await _ticketsService.CreateTickets(ticket);
        }

        [HttpPut("{id:int}")]
        public async Task<TicketDto> UpdateTickets(int id, TicketDto ticket)
        {
            return await _ticketsService.UpdateTickets(id, ticket);
        }

        [HttpDelete("{id:int}")]
        public async Task<string> DeleteTickets(int id)
        {
            return await _ticketsService.DeleteTickets(id);
        }

        [HttpGet("/byRef/{ref}")]
        public async Task<TicketDto> GetTicketRef(string @ref)
        {
            return await _ticketsService.GetTicketByRef(@ref);
        }

        [HttpGet("/byTrackId/{track_id}")]
        public async Task<TicketDto> GetTicketTrack(string track_id)
        {
            return await _ticketsService.GetTicketByTrackId(track_id);
        }
    }
}

