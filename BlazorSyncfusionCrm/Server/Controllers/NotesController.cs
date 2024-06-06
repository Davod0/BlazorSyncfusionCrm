using BlazorSyncfusionCrm.Server.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorSyncfusionCrm.Shared;
using BlazorSyncfusionCrm.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorSyncfusionCrm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly ICrudService<Note> _crudService;
        private readonly DataContext context;
        public NotesController(ICrudService<Note> crudService)
        {
            _crudService = crudService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Note>>> GetAllNotes()
        {
            var query =  _crudService.Include(n => n.Contact);
            var result = await query.ToListAsync();

            if (result.Count > 0)
            {
                return Ok(result);
            }
            return NotFound("There is no notes stored!");
        }


    }
}
