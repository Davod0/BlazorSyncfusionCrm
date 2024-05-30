using BlazorSyncfusionCrm.Server.Data;
using BlazorSyncfusionCrm.Server.Services;
using BlazorSyncfusionCrm.Shared;
using Microsoft.AspNetCore.Http;
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

    }
}
