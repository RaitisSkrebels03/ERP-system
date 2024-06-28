using Dollibar.Cllient.Dtos.MembersTypeDto;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface IMembersTypesService
    {
        Task<List<MembersTypeDto>> GetMembersTypes(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                     long? page = null, string? sqlFilters = null);
        Task<MembersTypeDto> GetMembersType(int id);
        Task<string> CreateMembersType(MembersTypeDto memberType);
        Task<MembersTypeDto> UpdateMembersType(int id, MembersTypeDto memberType);
        Task<string> DeleteMembersType(int id);
    }
}
