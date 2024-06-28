using Dollibar.Cllient.Services.Interfaces;
using Xunit.Extensions.Ordering;

namespace Dollibar.Test
{
    [Order(12)]
    public class StatusServiceTest
    {
        private readonly IStatusService _statusService;

        public StatusServiceTest(IStatusService statusService) => _statusService = statusService;

        [Fact, Order(1)]
        public async Task GetStatus()
        {
            var result = await _statusService.GetStatus();
            var code = result.Success.Code;
            Assert.Equal(code, "200");
        }
    }
}
