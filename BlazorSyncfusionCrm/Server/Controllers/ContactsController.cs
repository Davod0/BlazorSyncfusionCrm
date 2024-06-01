using BlazorSyncfusionCrm.Server.Data;
using BlazorSyncfusionCrm.Server.Services;
using BlazorSyncfusionCrm.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorSyncfusionCrm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactService _contactService;     

        public ContactsController(ContactService contactService)
        {
            _contactService = contactService;
        }


        [HttpGet("")]
        public async Task<ActionResult<List<Contact>>> GetAllContactsAsync()
        {
            return await _contactService.GetAllContacts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactByIdAsync(int id)
        {
            var result = await _contactService.GetContactByIdAsync(id);
            if (result == null)
            {
                return NotFound("Contact not found");
            }
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact(Contact c)
        {
            var result = await _contactService.CreateContactAsync(c);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("The new contact could not be created");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Contact>> UpdateContactAsync(int id, Contact c)
        {
            var result = _contactService.UpdateContactAsync(id, c);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("The contact could not be found");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Contact>>> DeleteContact(int id)
        {
            var result = _contactService.DeleteContact(id);
            if (result is not null)
            {
                return  await GetAllContactsAsync();
            }
            return NotFound("The contact could not be found");
        }
    }
}
