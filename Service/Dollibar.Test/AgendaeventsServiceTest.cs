using Dollibar.Cllient.Dtos.AgendaEventDto;
using Dollibar.Cllient.Services.Interfaces;
using Xunit.Extensions.Ordering;

namespace Dollibar.Test
{
    [Order(2)]
    public class AgendaEventsServiceTest
    {
        private readonly IAgendaEventsService _agendaEventsService;
        private static int agendaEventId;
        public AgendaEventsServiceTest(IAgendaEventsService agendaEventsService) => _agendaEventsService = agendaEventsService;

        [Fact, Order(1)]
        public async Task CreateAgendaEvent()
        {
            AgendaEventDto agendaEvent = new AgendaEventDto()
            {
                Entity = "1",
                Label = "12345",
                Type_id = "40",
                Note_private = "123",
                LabelStatus = "111",
                Elementid = "2",
                Elementtype = "user",
                Userownerid = "1"
            };
            var result = await _agendaEventsService.CreateAgendaEvent(agendaEvent);

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        [Fact, Order(2)]
        public async Task GetAgendaEvents()
        {
            var result = await _agendaEventsService.GetAgendaEvents();
            Assert.NotNull(result);
            Assert.IsType<List<AgendaEventDto>>(result);
            agendaEventId = result.Last().Id;
        }

        [Fact, Order(3)]
        public async Task GetAgendaEvent()
        {
            var result = await _agendaEventsService.GetAgendaEvent(agendaEventId);
            Assert.NotNull(result);
            Assert.IsType<AgendaEventDto>(result);
            Assert.Equal("1", result.Entity);
            Assert.Equal("40", result.Type_id);
        }

        [Fact, Order(4)]
        public async Task UpdateAgendaEvent()
        {
            AgendaEventDto agendaEvent = new AgendaEventDto()
            {
                Entity = "1",
                Label = "12345",
                Type_id = "40",
                Note_private = "123",
                LabelStatus = "111",
                Elementid = "2",
                Elementtype = "user",
                Userownerid = "1"

            };
            var result = await _agendaEventsService.UpdateAgendaEvent(agendaEventId, agendaEvent);
            Assert.NotNull(result);
            Assert.IsType<AgendaEventDto>(result);
            Assert.Equal("40", result.Type_id);
            Assert.Equal("111", result.LabelStatus);

        }

        [Fact, Order(5)]
        public async Task DeleteAgendaEvent()
        {
            var result = await _agendaEventsService.DeleteAgendaEvent(agendaEventId);
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

    }
}
