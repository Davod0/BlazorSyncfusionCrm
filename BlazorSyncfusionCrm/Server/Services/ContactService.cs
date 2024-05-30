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
            Contact c = new Contact();
            c = await _dataContext.Contacts.FindAsync(id);
            if (c != null)
            {
                return c;
            }
            return null;
        }
    }
}
