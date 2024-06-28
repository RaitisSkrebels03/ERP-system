using Dollibar.Cllient.Dtos.ContactDto;
using Dollibar.Cllient.Services.Interfaces;
using Xunit.Extensions.Ordering;

namespace Dollibar.Test
{
    [Order(4)]
    public class ContactsServiceTest
    {
        private readonly IContactsService _contactsService;
        private static int contactId;
        public ContactsServiceTest(IContactsService contactsService) => _contactsService = contactsService;

        [Fact, Order(1)]
        public async Task CreateContacts()
        {
            ContactDto contact = new ContactDto()
            {
                Entity = "1",
                Socid = "1",
                Lastname = "test",
                Firstname = "Toliks",
                Civility_code = "2"
            };
            var result = await _contactsService.CreateContact(contact);

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        [Fact, Order(2)]
        public async Task GetContacts()
        {
            var result = await _contactsService.GetContacts();
            Assert.NotNull(result);
            Assert.IsType<List<ContactDto>>(result);
            contactId = result.Last().Id;
        }

        [Fact, Order(3)]
        public async Task GetContact()
        {
            var result = await _contactsService.GetContact(contactId);
            Assert.NotNull(result);
            Assert.IsType<ContactDto>(result);
            Assert.Equal("1", result.Entity);
            Assert.Equal("1", result.Socid);
            Assert.Equal("test", result.Lastname);
            Assert.Equal("Toliks", result.Firstname);
        }

        [Fact, Order(4)]
        public async Task UpdateContact()
        {
            ContactDto contact = new ContactDto()
            {
                Entity = "1",
                Socid = "Socid",
                Lastname = "test",
                Firstname = "Toliks",
                Civility_code = "2"

            };
            var result = await _contactsService.UpdateContact(contactId, contact);
            Assert.NotNull(result);
            Assert.IsType<ContactDto>(result);
            Assert.Equal("test", result.Lastname);
            Assert.Equal("Toliks", result.Firstname);
        }

        [Fact, Order(5)]
        public async Task DeleteContact()
        {
            var result = await _contactsService.DeleteContact(contactId);
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

    }
}
