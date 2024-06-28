using Dollibar.Cllient.Dtos.MemberDto;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface IMembersService
    {
        Task<List<MemberDto>> GetMembers(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                        long? page = null, string? typeId = null, long? category = null, string? sqlFilters = null);
        Task<MemberDto> GetMember(int id);
        Task<string> CreateMember(MemberDto member);
        Task<MemberDto> UpdateMember(int id, MemberDto member);
        Task<string> DeleteMember(int id);
    }
}
