using Dollibar.Cllient.Dtos.InvoiceDto;
using Dollibar.Cllient.Services.Interfaces;
using Xunit.Extensions.Ordering;

namespace Dollibar.Test
{
    [Order(5)]
    public class InvoicesServiceTest
    {
        private readonly IInvoicesService _invoicesService;
        private static int invoicesId;
        public InvoicesServiceTest(IInvoicesService invoicesService) => _invoicesService = invoicesService;

        [Fact, Order(1)]
        public async Task CreateInvoice()
        {
            InvoiceDto invoice = new InvoiceDto()
            {
                Entity= "1",
                Fk_project = "2",
                Socid = "1",
                Fk_user_author = "4",
                Date = 1718841600
            };
            var result = await _invoicesService.CreateInvoice(invoice);

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        [Fact, Order(2)]
        public async Task GetInvoices()
        {
            var result = await _invoicesService.GetInvoices();
            Assert.NotNull(result);
            Assert.IsType<List<InvoiceDto>>(result);
            invoicesId = result.Last().Id;
        }

        [Fact, Order(3)]
        public async Task GetInvoice()
        {
            var result = await _invoicesService.GetInvoice(invoicesId);
            Assert.NotNull(result);
            Assert.IsType<InvoiceDto>(result);
            Assert.Equal("1", result.Entity);
            Assert.Equal("1", result.Socid);
            Assert.Equal("2", result.Fk_project);
            Assert.Equal(1718841600, result.Date);
            Assert.Equal("4", result.Fk_user_author);
        }

        [Fact, Order(4)]
        public async Task UpdateInvoice()
        {
            InvoiceDto invoice = new InvoiceDto()
            {
                Entity = "1",
                Fk_project = "2",
                Socid = "1",
                Fk_user_author = "5",
                Date = 1718873565

            };
            var result = await _invoicesService.UpdateInvoice(invoicesId, invoice);
            Assert.NotNull(result);
            Assert.IsType<InvoiceDto>(result);
            Assert.Equal("1", result.Socid);
            Assert.Equal("2", result.Fk_project);
        }

        [Fact, Order(5)]
        public async Task DeleteInvoice()
        {
            var result = await _invoicesService.DeleteInvoice(invoicesId);
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }
    }
}
