using Microsoft.AspNetCore.Mvc;
using NotesApi.Models;
using NotesApi.Services;

namespace NotesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Note>> Get()
        {
            return Ok(_noteService.GetAll());
        }

        [HttpPost]
        public IActionResult Post(Note note)
        {
            _noteService.Add(note);
            return CreatedAtAction(nameof(Get), new { id = note.Id }, note);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _noteService.Delete(id);
            return NoContent();
        }
    }
}
