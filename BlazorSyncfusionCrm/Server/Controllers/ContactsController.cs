using BlazorSyncfusionCrm.Server.Data;
using BlazorSyncfusionCrm.Server.Interfaces;
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
        private readonly ICrudService<Contact> _crudService;

        public ContactsController(ICrudService<Contact> crudService)
        {
            _crudService = crudService;
        }


        [HttpGet("")]
        public async Task<ActionResult<List<Contact>>> GetAllContactsAsync()
        {
            return await _crudService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactByIdAsync(int id)
        {
            var result = await _crudService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound("Contact not found");
            }
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact(Contact c)
        {
            var result = await _crudService.AddAsync(c);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("The new contact could not be created");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Contact>> UpdateContactAsync(int id, Contact c)
        {
            var result = await _crudService.UpdateAsync(id, c);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("The contact could not be found");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Contact>>> DeleteContact(int id)
        {
            var result = await _crudService.DeleteAsync(id);
            if (result is not null)
            {
                return  await GetAllContactsAsync();
            }
            return NotFound("The contact could not be found");
        }
    }
}
