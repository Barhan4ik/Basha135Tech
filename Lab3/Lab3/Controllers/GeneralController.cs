using Lab3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Lab3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private readonly TypeofworkContext _сontext;


        public GeneralController(TypeofworkContext сontext)
        {
            _сontext = сontext;
        }
        //GET
        [HttpGet("GetFull")]
        public async Task<ActionResult<IEnumerable<Typeofwork>>> GetTypeofworks()
        {
            if (_сontext.Typeofworks == null)
            {
                return NotFound();
            }
            return await _сontext.Typeofworks.ToListAsync();
        }

        //GET ID
        [HttpGet("Typeofwork/{id}")]
        public async Task<ActionResult<Typeofwork>> GetTypeofwork(int id)
        {
            if (_сontext.Typeofworks == null)
            {
                return NotFound();
            }
            var typeofwork = await _сontext.Typeofworks.FindAsync(id);
            if (typeofwork == null)
            {
                return NotFound();
            }

            return typeofwork;
        }
        //GET W_ID
        [HttpGet("Workcatalog/{id}")]
        public async Task<ActionResult<Workcatalog>> GetWorkcatalog(int id)
        {
            if (_сontext.Workcatalogs == null)
            {
                return NotFound();
            }
            var workcatalog = await _сontext.Workcatalogs.FindAsync(id);
            if (workcatalog == null)
            {
                return NotFound();
            }

            return workcatalog;
        }
        //POST 
        [HttpPost("Typeofwork")]
        public async Task<ActionResult<Typeofwork>> PostTypeofwork(Typeofwork typeofwork)
        {
            _сontext.Typeofworks.Add(typeofwork);
            await _сontext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTypeofwork), new { id = typeofwork.Id }, typeofwork);
        }
        [HttpPost("Workcatalog")]
        public async Task<ActionResult<Workcatalog>> PostWorkcatalog(Workcatalog workcatalog)
        {
            _сontext.Workcatalogs.Add(workcatalog);
            await _сontext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTypeofwork), new { id = workcatalog.Id }, workcatalog);
        }
        [HttpPut("Typeofwork/{id}")]
        public async Task<IActionResult> PutTypeofwork(int id, Typeofwork typeofwork)
        {
            if (id != typeofwork.Id)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpPut("Workcatalog/{id}")]
        public async Task<IActionResult> PutWorkcatalog(int id, Workcatalog workcatalog)
        {
            if (id != workcatalog.Id)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("Typeofwork/{id}")]
        public async Task<IActionResult> DeleteTypeofwork(int id)
        {
            if (_сontext.Typeofworks == null)
            {
                return NotFound();
            }
            var typeofwork = await _сontext.Typeofworks.FindAsync(id);
            if (typeofwork == null)
            {
                return NotFound();
            }

            _сontext.Typeofworks.Remove(typeofwork);
            await _сontext.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("Workcatalog/{id}")]
        public async Task<IActionResult> DeleteWorkcatalog(int id)
        {
            if (_сontext.Workcatalogs == null)
            {
                return NotFound();
            }
            var workcatalog = await _сontext.Workcatalogs.FindAsync(id);
            if (workcatalog == null)
            {
                return NotFound();
            }

            _сontext.Workcatalogs.Remove(workcatalog);
            await _сontext.SaveChangesAsync();

            return NoContent();
        }
    }
}
