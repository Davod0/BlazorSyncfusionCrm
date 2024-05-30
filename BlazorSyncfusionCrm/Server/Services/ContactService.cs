using BlazorSyncfusionCrm.Server.Data;
using BlazorSyncfusionCrm.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorSyncfusionCrm.Server.Services
{
    public class ContactService
    {
        private readonly DataContext _dataContext;
        public ContactService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            List<Contact> contacts = new List<Contact>();
            contacts = await _dataContext.Contacts.ToListAsync();
            if (contacts.Count > 0)
            {
                return contacts;
            }
            return null;
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            var c = new Contact();
            c = await _dataContext.Contacts.FindAsync(id);
            if (c is not null)
            {
                return c;
            }
            return null;
        }

        public async Task<Contact> CreateContactAsync(Contact c)
        {
            _dataContext.Contacts.AddAsync(c);
            await _dataContext.SaveChangesAsync();
            return c; 
        }

        public async Task<Contact> UpdateContactAsync(int id, Contact c)
        {
            var contact = await _dataContext.Contacts.FindAsync(id);
            if (contact == null)
            {
                return null; 
            }
            contact.FirstName = c.FirstName;
            contact.LastName = c.LastName;
            contact.NickName = c.NickName;
            contact.DateOfBirth = c.DateOfBirth;
            contact.Place = c.Place;
            contact.DateUpdated = DateTime.Now;
            await _dataContext.SaveChangesAsync();

            return contact;
        }
    }
}
