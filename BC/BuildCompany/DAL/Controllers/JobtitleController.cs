using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Interior_decorating_company.DAL.Controllers
{
    [ApiController]
    [Route("/Jobtitle")]
    public class JobtitleController : ControllerBase
    {
        ApplicationContext db;
        public JobtitleController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jobtitle>>> Get()
        {
            return await db.Jobtitles.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jobtitle>> Get(int Id)
        {
            Jobtitle jobtitle = await db.Jobtitles.FirstOrDefaultAsync(x => x.Job_Id == Id);
            if (jobtitle == null)
                return NotFound();
            return new ObjectResult(jobtitle);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Jobtitle>> Post(Jobtitle jobtitle)
        {
            if (jobtitle == null)
            {
                return BadRequest();
            }

            db.Jobtitles.Add(jobtitle);
            await db.SaveChangesAsync();
            return Ok(jobtitle);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Jobtitle>> Put(Jobtitle jobtitle)
        {
            if (jobtitle == null)
            {
                return BadRequest();
            }
            if (!db.Jobtitles.Any(x => x.Job_Id == jobtitle.Job_Id))
            {
                return NotFound();
            }

            db.Update(jobtitle);
            await db.SaveChangesAsync();
            return Ok(jobtitle);
        }

        // DELETE api/users/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Jobtitle>> Delete(int Id)
        {
            Jobtitle jobtitle = db.Jobtitles.FirstOrDefault(x => x.Job_Id == Id);
            if (jobtitle == null)
            {
                return NotFound();
            }
            db.Jobtitles.Remove(jobtitle);
            await db.SaveChangesAsync();
            return Ok(jobtitle);
        }
    }
}