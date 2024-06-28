using Dollibar.Cllient.Dtos.ProposalsDto;
using Dollibar.Cllient.Services.Interfaces;
using Xunit.Extensions.Ordering;

namespace Dollibar.Test
{
    [Order(10)]
    public class ProposalsServiceTest
    {
        private readonly IProposalsService _proposalsService;
        private static int proposalId;
        public ProposalsServiceTest(IProposalsService proposalsService) => _proposalsService = proposalsService;

        [Fact, Order(1)]
        public async Task CreateProposal()
        {
            ProposalDto proposal = new  ProposalDto ()
            {
                Ref = "(PROV11)", 
                Entity = "1",
                Mode_reglement_id = "7",
                Cond_reglement_id = "10",
                Demand_reason_id = "11",
                Socid = "1",
                Date = 1710576527,
                Statut = 1

            };
            var result = await _proposalsService.CreateProposal(proposal);

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        [Fact, Order(2)]
        public async Task GetProposals()
        {
            var result = await _proposalsService.GetProposals();
            Assert.NotNull(result);
            Assert.IsType<List<ProposalDto>>(result);
            proposalId = result.Last().Id;
        }

        [Fact, Order(3)]
        public async Task GetProposal()
        {
            var result = await _proposalsService.GetProposal(proposalId);
            Assert.NotNull(result);
            Assert.IsType<ProposalDto>(result);
            Assert.Equal("7", result.Mode_reglement_id);
            Assert.Equal("10", result.Cond_reglement_id);
            Assert.Equal("11", result.Demand_reason_id);
            Assert.Equal("1", result.Socid);
        }

        [Fact, Order(4)]
        public async Task UpdateProposal()
        {
            ProposalDto proposal = new ProposalDto()
            {
                Ref = "(PROV11)",
                Entity = "1",
                Mode_reglement_id = "7",
                Cond_reglement_id = "10",
                Demand_reason_id = "11",
                Socid = "1",
                Statut = 1,
                Date = 1710576527,
            };
            var result = await _proposalsService.UpdateProposal(proposalId, proposal);
            Assert.NotNull(result);
            Assert.IsType<ProposalDto>(result);
            Assert.Equal("10", result.Cond_reglement_id);
            Assert.Equal("1", result.Entity);
            Assert.Equal("1", result.Socid);
        }

        [Fact, Order(5)]
        public async Task DeleteProposal()
        {
            var result = await _proposalsService.DeleteProposal(proposalId);
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }
    }
}
