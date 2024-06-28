using Dollibar.Cllient.Dtos.MembersTypeDto;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dollibar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersTypesController
    {
        private readonly IMembersTypesService _membersTypesService;

        public MembersTypesController(IMembersTypesService membersTypesService)
        {
            _membersTypesService = membersTypesService;
        }
        [HttpGet]
        public async Task<List<MembersTypeDto>> GetTasks(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                                  long? page = null, string? sqlFilters = null)
        {
            return await _membersTypesService.GetMembersTypes(sortfield, sortorder, limit, page, sqlFilters);
        }

        [HttpGet("{id:int}")]
        public async Task<MembersTypeDto> GetTask(int id)
        {
            return await _membersTypesService.GetMembersType(id);
        }

        [HttpPost]
        public async Task<string> CreateTask(MembersTypeDto membersType)
        {
            return await _membersTypesService.CreateMembersType(membersType);
        }

        [HttpPut("{id:int}")]
        public async Task<MembersTypeDto> UpdateTask(int id, MembersTypeDto membersType)
        {
            return await _membersTypesService.UpdateMembersType(id, membersType);
        }

        [HttpDelete("{id:int}")]
        public async Task<string> DeleteTask(int id)
        {
            return await _membersTypesService.DeleteMembersType(id);
        }
    }
}
