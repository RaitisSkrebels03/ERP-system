using Dollibar.Cllient.Dtos.ContactDto;
using Dollibar.Cllient.Dtos.ProjectDto;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface IContactsService
    {
        Task<List<ContactDto>> GetContacts(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                           long? page = null, string? thirdparty_ids = null, long? category = null,
                                           string? sqlfilters = null, long? includecount = null, long? includeroles = null);
        Task<ContactDto> GetContact(int id);
        Task<string> CreateContact(ContactDto contact);
        Task<ContactDto> UpdateContact(int id, ContactDto contact);
        Task<string> DeleteContact(int id);
    }
}
