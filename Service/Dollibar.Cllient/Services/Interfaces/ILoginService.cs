using Dollibar.Cllient.Dtos;
using Dollibar.Cllient.Dtos.LoginDto;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponseDto> Login(string login, string password, string? entity = null, int reset = 0);
    }
}