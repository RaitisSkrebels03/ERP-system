using Dollibar.Cllient.Dtos.ThirdPartyDto;
using Dollibar.Cllient.Services.Interfaces;
using Xunit.Extensions.Ordering;

namespace Dollibar.Test
{
    [Order(14)]
    public class ThirdpartiesServiceTest
    {
        private readonly IThirdpartiesService _thirdpartiesService;
        private static int thirdpartiesId;
        public ThirdpartiesServiceTest(IThirdpartiesService thirdpartiesService) => _thirdpartiesService = thirdpartiesService;

        [Fact, Order(1)]
        public async Task CreateThirdParty()
        {
            ThirdPartyDto thirdParty = new ThirdPartyDto()
            {
                Entity = "1",
                Name = "Test",
                Ref = "11"
            };
            var result = await _thirdpartiesService.CreateThirdParty(thirdParty);

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        [Fact, Order(2)]
        public async Task GetThirdParties()
        {
            var result = await _thirdpartiesService.GetThirdParties();
            Assert.NotNull(result);
            Assert.IsType<List<ThirdPartyDto>>(result);
            thirdpartiesId = result.Last().Id;
        }

        [Fact, Order(3)]
        public async Task GetThirdParty()
        {
            var result = await _thirdpartiesService.GetThirdParty(thirdpartiesId);
            Assert.NotNull(result);
            Assert.IsType<ThirdPartyDto>(result);
            Assert.Equal("Test", result.Name);
            Assert.Equal("1", result.Entity);
        }

        [Fact, Order(4)]
        public async Task UpdateThirdParty()
        {
            ThirdPartyDto thirdParty = new ThirdPartyDto()
            {
                Entity = "1",
                Name = "Test",

            };
            var result = await _thirdpartiesService.UpdateThirdParty(thirdpartiesId, thirdParty);
            Assert.NotNull(result);
            Assert.IsType<ThirdPartyDto>(result);
            Assert.Equal("Test", result.Name);
            Assert.Equal("1", result.Entity);
        }

        [Fact, Order(5)]
        public async Task DeleteThirdParty()
        {
            var result = await _thirdpartiesService.DeleteThirdParty(thirdpartiesId);
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

    }
}
