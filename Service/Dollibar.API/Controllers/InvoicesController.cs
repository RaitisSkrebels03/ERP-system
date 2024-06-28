using Dollibar.Cllient.Dtos.InvoiceDto;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dollibar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController
    {
        private readonly IInvoicesService _invoicesService;

        public InvoicesController(IInvoicesService invoicesService)
        {
            _invoicesService = invoicesService;
        }

        [HttpGet]
        public async Task<List<InvoiceDto>> GetInvoices(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                                  long? page = null, string? thirdparty_ids = null, string? status = null, string ? sqlFilters = null)
        {
            return await _invoicesService.GetInvoices(sortfield, sortorder, limit, page, thirdparty_ids, status, sqlFilters);
        }

        [HttpGet("{id:int}")]
        public async Task<InvoiceDto> GetInvoice(int id)
        {
            return await _invoicesService.GetInvoice(id);
        }

        [HttpPost]
        public async Task<string> CreateInvoice(InvoiceDto invoice)
        {
            return await _invoicesService.CreateInvoice(invoice);
        }

        [HttpPut("{id:int}")]
        public async Task<InvoiceDto> UpdateInvoice(int id, InvoiceDto invoice)
        {
            return await _invoicesService.UpdateInvoice(id, invoice);
        }

        [HttpDelete("{id:int}")]
        public async Task<string> DeleteInvoice(int id)
        {
            return await _invoicesService.DeleteInvoice(id);
        }
    }
}
