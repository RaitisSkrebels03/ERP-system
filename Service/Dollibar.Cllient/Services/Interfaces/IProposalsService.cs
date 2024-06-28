using Dollibar.Cllient.Dtos.ProposalsDto;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface IProposalsService
    {
        Task<List<ProposalDto>> GetProposals(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                                        long? page = null, string? thirdparty_ids = null, string? sqlFilters = null);

        Task<ProposalDto> GetProposal(int id);
        Task<string> CreateProposal(ProposalDto proposal);
        Task<ProposalDto> UpdateProposal(int id, ProposalDto proposal);
        Task<string> DeleteProposal(int id);

    }
}
