using Dollibar.Cllient.Dtos.UsersDto;
using Dollibar.Cllient.Services.Interfaces;
using Xunit.Extensions.Ordering;

namespace Dollibar.Test
{
    [Order(16)]
    public class UsersServiceTest
    {
        private readonly IUsersService _usersService;
        private static int userId;
        public UsersServiceTest(IUsersService usersService) => _usersService = usersService;

        [Fact, Order(1)]
        public async Task CreateUser()
        {
            UserDto user = new UserDto()
            {
                Entity = "1",
                Civility_code = "2",
                Lastname = "Test",
                Firstname = "Toliks",
                Login = "asdfghjkl",
                Employee = "1",
                Fk_user = 1,
                Admin = 0
            };
            var result = await _usersService.CreateUser(user);

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        [Fact, Order(2)]
        public async Task GetUsers()
        {
            var result = await _usersService.GetUsers();
            Assert.NotNull(result);
            Assert.IsType<List<UserDto>>(result);
            userId = result.Last().Id;
        }

        [Fact, Order(3)]
        public async Task GetUser()
        {
            var result = await _usersService.GetUser(userId);
            Assert.NotNull(result);
            Assert.IsType<UserDto>(result);
            Assert.Equal("1", result.Entity);
            Assert.Equal("Test", result.Lastname);
            Assert.Equal("Toliks", result.Firstname);
        }

        [Fact, Order(4)]
        public async Task UpdateUser()
        {
            UserDto user = new UserDto()
            {
                Entity = "1",
                Civility_code = "2",
                Lastname = "Test",
                Firstname = "Toliks",
                Login = "asdfghjkl",
                Employee = "1",
                Fk_user = 1,
                Admin = 0
            };
            var result = await _usersService.UpdateUser(userId, user);
            Assert.NotNull(result);
            Assert.IsType<UserDto>(result);
            Assert.Equal("Test", result.Lastname);
            Assert.Equal("Toliks", result.Firstname);
            Assert.Equal("2", result.Civility_code);

        }

        [Fact, Order(5)]
        public async Task DeleteUser()
        {
            var result = await _usersService.DeleteUser(userId);
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }
    }

}

