using Dollibar.Cllient.Dtos.InvoiceDto;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface IInvoicesService
    {
        Task<List<InvoiceDto>> GetInvoices(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                     long? page = null, string? thirdparty_ids = null, string? status = null, string? sqlFilters = null);
        Task<InvoiceDto> GetInvoice(int id);
        Task<string> CreateInvoice(InvoiceDto invoice);
        Task<InvoiceDto> UpdateInvoice(int id, InvoiceDto invoice);
        Task<string> DeleteInvoice(int id);
    }
}
