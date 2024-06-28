using Dollibar.Cllient.Dtos.ContactDto;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dollibar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController
    {
        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        [HttpGet]
        public async Task<List<ContactDto>> GetContacts(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100, 
                                                        long? page = null, string? thirdparty_ids = null, long? category = null,
                                                        string? sqlfilters = null, long? includecount = null, long? includeroles = null)
        {
            return await _contactsService.GetContacts(sortfield, sortorder, limit, page, thirdparty_ids, category, sqlfilters, includecount, includeroles);
        }

        [HttpGet("{id:int}")]
        public async Task<ContactDto> GetContact(int id)
        {
            return await _contactsService.GetContact(id);
        }

        [HttpPost]
        public async Task<string> CreateContact(ContactDto contact)
        {
            return await _contactsService.CreateContact(contact);
        }

        [HttpPut("{id:int}")]
        public async Task<ContactDto> UpdateContact(int id, ContactDto contact)
        {
            return await _contactsService.UpdateContact(id, contact);
        }

        [HttpDelete("{id:int}")]
        public async Task<string> DeleteContact(int id)
        {
            return await _contactsService.DeleteContact(id);
        }

    }
}
