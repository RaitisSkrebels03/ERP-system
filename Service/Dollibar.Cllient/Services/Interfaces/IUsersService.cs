using Dollibar.Cllient.Dtos.UsersDto;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface IUsersService
    {
        Task<List<UserDto>> GetUsers(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                     long? page = null, string? user_ids = null, long? category = null, string? sqlFilters = null);
        Task<UserDto> GetUser(int id);
        Task<UserDto> GetCurrentUser();
        Task<string> CreateUser(UserDto user);
        Task<UserDto> UpdateUser(int id, UserDto user);
        Task<string> DeleteUser(int id);

    }
}
