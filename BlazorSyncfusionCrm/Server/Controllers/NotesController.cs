using BlazorSyncfusionCrm.Server.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorSyncfusionCrm.Shared;
using BlazorSyncfusionCrm.Server.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using BlazorSyncfusionCrm.Server.Services;

namespace BlazorSyncfusionCrm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly ICrudService<Note> _crudService;
        public NotesController(ICrudService<Note> crudService)
        {
            _crudService = crudService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Note>>> GetAllNotes()
        {
            var query =  _crudService.Include(n => n.Contact);
            var result = await query.OrderByDescending(n => n.DateCreated).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{contactId}")]
        public async Task<ActionResult<List<Note>>> GetNotesFromContact(int contactId)
        {
            if (contactId != 0)
            {
                var query = _crudService.Where(n => n.ContactId == contactId);
                var result = await query.OrderByDescending(n => n.DateCreated).ToListAsync();
                if(result != null)
                {
                    return Ok(result);
                }
                return NotFound("The item with specific ID could not be found");
            }
            return BadRequest("The Contact ID can not be noll!");
        }

        [HttpPost]
        public async Task<ActionResult<List<Note>>> CreateNote(Note note)
        {
            if (note != null)
            {
                await _crudService.AddAsync(note);
                var result = _crudService.Where(n => n.ContactId == note.ContactId)
                    .OrderByDescending(n => n.DateCreated)
                    .ToListAsync();
                return Ok(result);
            }
            return BadRequest("The Note can not be null!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Note>>> DeleteNote(int id)
        {
            if (id != 0)
            {
                var result = _crudService.DeleteAsync(id);
                if(result is not null)
                {
                    return await GetNotesFromContact(id);
                }
            }
            return BadRequest("The ID can not be null!");
        }
    }
}


