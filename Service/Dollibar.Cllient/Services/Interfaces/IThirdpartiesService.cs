using Dollibar.Cllient.Dtos.ThirdPartyDto;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface IThirdpartiesService
    {
        Task<List<ThirdPartyDto>> GetThirdParties(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                                  long? page = null, long? mode = null, long? category = null, string? sqlfilters = null);
        Task<ThirdPartyDto> GetThirdParty(int id);
        Task<string> CreateThirdParty(ThirdPartyDto thirdParty);
        Task<ThirdPartyDto> UpdateThirdParty(int id, ThirdPartyDto thirdParty);
        Task<string> DeleteThirdParty(int id);
    }
}
