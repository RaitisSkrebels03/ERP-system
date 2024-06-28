using Dollibar.Cllient.Dtos.ProposalsDto;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dollibar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProposalsController
    {
        private readonly IProposalsService _proposalsService;

        public ProposalsController(IProposalsService proposalsService)
        {
            _proposalsService = proposalsService;
        }

        [HttpGet]
        public async Task<List<ProposalDto>> GetProposals(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                                  long? page = null, string? thirdparty_ids = null, string? sqlFilters = null)
        {
            return await _proposalsService.GetProposals(sortfield, sortorder, limit, page, thirdparty_ids, sqlFilters);
        }

        [HttpGet("{id:int}")]
        public async Task<ProposalDto> GetProposal(int id)
        {
            return await _proposalsService.GetProposal(id);
        }

        [HttpPost]
        public async Task<string> CreateProposal(ProposalDto proposal)
        {
            return await _proposalsService.CreateProposal(proposal);
        }

        [HttpPut("{id:int}")]
        public async Task<ProposalDto> UpdateProposal(int id, ProposalDto proposal)
        {
            return await _proposalsService.UpdateProposal(id, proposal);
        }

        [HttpDelete("{id:int}")]
        public async Task<string> DeleteProposal(int id)
        {
            return await _proposalsService.DeleteProposal(id);
        }
    }
}
