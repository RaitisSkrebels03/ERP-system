using Dollibar.Cllient.Dtos.UsersDto;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dollibar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<List<UserDto>> GetUsers(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100, long? 
                                                  page = null, string? user_ids = null, long? category = null, string? sqlFilters = null)
        {
            return await _usersService.GetUsers(sortfield, sortorder, limit, page, user_ids, category, sqlFilters);
        }

        [HttpGet("/current")]
        public async Task<UserDto> GetCurrentUser()
        {
            return await _usersService.GetCurrentUser();
        }

        [HttpGet("{id:int}")]
        public async Task<UserDto> GetUser(int id)
        {
            return await _usersService.GetUser(id);
        }

        [HttpPost]
        public async Task<string> CreateUser(UserDto user)
        {
            return await _usersService.CreateUser(user);
        }

        [HttpPut("{id:int}")]
        public async Task<UserDto> UpdateUser(int id, UserDto user)
        {
            return await _usersService.UpdateUser(id, user);
        }

        [HttpDelete("{id:int}")]
        public async Task<string> DeleteUser(int id)
        {
            return await _usersService.DeleteUser(id);
        }
    }
}
