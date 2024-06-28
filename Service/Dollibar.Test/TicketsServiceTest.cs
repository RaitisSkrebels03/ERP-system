using Dollibar.Cllient.Dtos.TicketDto;
using Dollibar.Cllient.Services.Interfaces;
using Xunit.Extensions.Ordering;

namespace Dollibar.Test
{
    [Order(15)]
    public class TicketsServiceTest
    {
        private readonly ITicketsService _ticketsService;
        private static int ticketId;

        public TicketsServiceTest(ITicketsService ticketsService) => _ticketsService = ticketsService;

        [Fact, Order(1)]
        public async Task CreateTickets()
        {
            TicketDto tickets = new TicketDto()
            {

                Entity = "1",
                Fk_project = "1",
                Subject = "21",
                Message = "12345"
            };
            var result = await _ticketsService.CreateTickets(tickets);

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        [Fact, Order(2)]
        public async Task GetTickets()
        {
            var result = await _ticketsService.GetTickets();
            Assert.NotNull(result);
            Assert.IsType<List<TicketDto>>(result);
            ticketId = result.Last().Id;
        }

        [Fact, Order(3)]
        public async Task GetTicket()
        {
            var result = await _ticketsService.GetTicket(ticketId);
            Assert.NotNull(result);
            Assert.IsType<TicketDto>(result);
            Assert.Equal("1", result.Entity);
            Assert.Equal("1", result.Fk_project);
        }

        //[Fact, Order(4)]
        //public async Task UpdateTickets()
        //{
        //    TicketDto tickets = new TicketDto()
        //    {
        //        Fk_project = "1",
        //        Subject = "22",
        //        Message = "12345678"
        //    };
        //    var result = await _ticketsService.UpdateTickets(ticketId, tickets);
        //    Assert.NotNull(result);
        //    Assert.IsType<TicketDto>(result);
        //    Assert.Equal("1", result.Entity);
        //    Assert.Equal("1", result.Fk_project);
        //}

        [Fact, Order(4)]
        public async Task DeleteTickets()
        {
            var result = await _ticketsService.DeleteTickets(ticketId);
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

    }
}
