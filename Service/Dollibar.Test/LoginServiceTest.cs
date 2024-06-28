using Dollibar.Cllient;
using Dollibar.Cllient.Services.Interfaces;
using Xunit.Extensions.Ordering;

namespace Dollibar.Test
{
    [Order(1)]
    public class LoginServiceTest
    {
        private readonly ILoginService _loginService;

        public LoginServiceTest(ILoginService loginService) => _loginService = loginService;

        [Fact, Order(1)]
        public async Task GetApiResponseAsync()
        {
            var result = await _loginService.Login("isavicka", "dm9v3sllFZJZ");
            var code = result.Success.Code;
            Assert.Equal(code, 200);
            Token.DOLAPIKEY = result.Success.Token;
        }
    }
}
