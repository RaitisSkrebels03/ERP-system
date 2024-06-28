using Dollibar.Cllient.Dtos.ThirdPartyDto;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dollibar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThirdpartiesController
    {
        private readonly IThirdpartiesService _thirdPartiesService;

        public ThirdpartiesController(IThirdpartiesService thirdPartiesService)
        {
            _thirdPartiesService = thirdPartiesService;
        }

        [HttpGet]
        public async Task<List<ThirdPartyDto>> GetThirdParties(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                                               long? page = null, long? mode = null, long? category = null, string? sqlfilters = null)
        {
            return await _thirdPartiesService.GetThirdParties(sortfield, sortorder, limit, page, mode, category, sqlfilters);
        }

        [HttpGet("{id:int}")]
        public async Task<ThirdPartyDto> GetThirdParty(int id)
        {
            return await _thirdPartiesService.GetThirdParty(id);
        }

        [HttpPost]
        public async Task<string> CreateThirdParty(ThirdPartyDto thirdParty)
        {
            return await _thirdPartiesService.CreateThirdParty(thirdParty);
        }

        [HttpPut("{id:int}")]
        public async Task<ThirdPartyDto> UpdateThirdParty(int id, ThirdPartyDto thirdParty)
        {
            return await _thirdPartiesService.UpdateThirdParty(id, thirdParty);
        }

        [HttpDelete("{id:int}")]
        public async Task<string> DeleteThirdParty(int id)
        {
            return await _thirdPartiesService.DeleteThirdParty(id);
        }
    }
}
