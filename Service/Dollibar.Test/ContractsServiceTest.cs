using Dollibar.Cllient.Dtos.ContractsDto;
using Dollibar.Cllient.Dtos.TaskDto;
using Dollibar.Cllient.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Extensions.Ordering;

namespace Dollibar.Test
{
    [Order(7)]
    public class ContractsServiceTest
    {
        private readonly IContractsService _contractsService;
        private static int contractsId;
        public ContractsServiceTest(IContractsService contractsService) => _contractsService = contractsService;

        [Fact, Order(1)]
        public async Task CreateContract()
        {
            ContractsDto contracts = new ContractsDto()
            {

                Socid = "1",
                Date_contrat = "2",
                commercial_signature_id = "111",
                commercial_suivi_id = "111"

            };
            var result = await _contractsService.CreateContract(contracts);

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        [Fact, Order(2)]
        public async Task GetContracts()
        {
            var result = await _contractsService.GetContracts();
            Assert.NotNull(result);
            Assert.IsType<List<ContractsDto>>(result);
            contractsId = result.Last().Id;
        }

        [Fact, Order(3)]
        public async Task GetContract()
        {
            var result = await _contractsService.GetContract(contractsId);
            Assert.NotNull(result);
            Assert.IsType<ContractsDto>(result);
            Assert.Equal("1", result.Socid);
            Assert.Equal("2", result.Date_contrat);
            Assert.Equal("111", result.commercial_signature_id);
            Assert.Equal("111", result.commercial_suivi_id);
        }

        [Fact, Order(4)]
        public async Task UpdateContract()
        {
            ContractsDto contracts = new ContractsDto()
            {
                Socid = "1",
                Date_contrat = "2",
                commercial_signature_id = "111",
                commercial_suivi_id = "111"


            };
            var result = await _contractsService.UpdateContract(contractsId, contracts);
            Assert.NotNull(result);
            Assert.IsType<ContractsDto>(result);
            Assert.Equal("1", result.Socid);
            Assert.Equal("111", result.commercial_signature_id);
        }

        [Fact, Order(5)]
        public async Task DeleteContract()
        {
            var result = await _contractsService.DeleteContract(contractsId);
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        
    }
}
