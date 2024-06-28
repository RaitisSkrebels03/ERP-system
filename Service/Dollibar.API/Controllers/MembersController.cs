using Dollibar.Cllient.Dtos.MemberDto;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dollibar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController
    {
        private readonly IMembersService _membersService;

        public MembersController(IMembersService membersService)
        {
            _membersService = membersService;
        }

        [HttpGet]
        public async Task<List<MemberDto>> GetMembers(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                                      long? page = null, string? typeId = null, long? category = null, string? sqlFilters = null)
        {
            return await _membersService.GetMembers(sortfield, sortorder, limit, page, typeId, category, sqlFilters);
        }

        [HttpGet("{id:int}")]
        public async Task<MemberDto> GetMember(int id)
        {
            return await _membersService.GetMember(id);
        }

        [HttpPost]
        public async Task<string> CreateMember(MemberDto member)
        {
            return await _membersService.CreateMember(member);
        }

        [HttpPut("{id:int}")]
        public async Task<MemberDto> UpdateMember(int id, MemberDto member)
        {
            return await _membersService.UpdateMember(id, member);
        }

        [HttpDelete("{id:int}")]
        public async Task<string> DeleteMember(int id)
        {
            return await _membersService.DeleteMember(id);
        }
    }
}
