using Dollibar.Cllient.Dtos.LoginDto;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dollibar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<LoginResponseDto> Login(string login, string password, string? entity = null, int reset = 0)
        {

            return await _loginService.Login(login, password, entity, reset);
        }
    }
}

