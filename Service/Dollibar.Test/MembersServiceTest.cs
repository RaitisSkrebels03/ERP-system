using Dollibar.Cllient.Dtos.MemberDto;
using Dollibar.Cllient.Services.Interfaces;
using Xunit.Extensions.Ordering;

namespace Dollibar.Test
{
    [Order(6)]
    public class MembersServiceTest
    {
        private readonly IMembersService _membersService;
        private static int memberId;
        public MembersServiceTest(IMembersService membersService) => _membersService = membersService;

        [Fact, Order(1)]
        public async Task CreateMember()
        {
            MemberDto member = new MemberDto()
            {
                Lastname = "Test",
                Firstname = "Toliks",
                Morphy = "eee",
                Typeid = "1",
                Entity = 1,
            };
            var result = await _membersService.CreateMember(member);

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        [Fact, Order(2)]
        public async Task GetMembers()
        {
            var result = await _membersService.GetMembers();
            Assert.NotNull(result);
            Assert.IsType<List<MemberDto>>(result);
            memberId = result.Last().Id;
        }

        [Fact, Order(3)]
        public async Task GetMember()
        {
            var result = await _membersService.GetMember(memberId);
            Assert.NotNull(result);
            Assert.IsType<MemberDto>(result);
            Assert.Equal("1", result.Typeid);
            Assert.Equal("eee", result.Morphy);
            Assert.Equal(1, result.Entity);
        }

        [Fact, Order(4)]
        public async Task UpdateMember()
        {
            MemberDto member = new MemberDto()
            {
                Lastname = "Test",
                Firstname = "Toliks",
                Morphy = "eee",
                Typeid = "1",
                Entity = 1,
                Ref = "8"

            };
            var result = await _membersService.UpdateMember(memberId, member);
            Assert.NotNull(result);
            Assert.IsType<MemberDto>(result);
            Assert.Equal("eee", result.Morphy);
            Assert.Equal("1", result.Typeid);
        }

        [Fact, Order(5)]
        public async Task DeleteMember()
        {
            var result = await _membersService.DeleteMember(memberId);
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

    }
}
