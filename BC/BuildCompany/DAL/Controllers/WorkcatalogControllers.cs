using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Interior_decorating_company.DAL.Controllers
{
    [ApiController]
    [Route("/Workcatalog")]
    public class WorkcatalogController : ControllerBase

    {
        ApplicationContext db;
        public WorkcatalogController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workcatalog>>> Get()
        {
            return await db.Workcatalogs.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workcatalog>> Get(int Id)
        {
            Workcatalog workcatalog = await db.Workcatalogs.FirstOrDefaultAsync(x => x.Workcatalog_Id == Id);
            if (workcatalog == null)
                return NotFound();
            return new ObjectResult(workcatalog);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Workcatalog>> Post(Workcatalog workcatalog)
        {
            if (workcatalog == null)
            {
                return BadRequest();
            }

            db.Workcatalogs.Add(workcatalog);
            await db.SaveChangesAsync();
            return Ok(workcatalog);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Workcatalog>> Put(Workcatalog workcatalog)
        {
            if (workcatalog == null)
            {
                return BadRequest();
            }
            if (!db.Workcatalogs.Any(x => x.Workcatalog_Id == workcatalog.Workcatalog_Id))
            {
                return NotFound();
            }

            db.Update(workcatalog);
            await db.SaveChangesAsync();
            return Ok(workcatalog);
        }

        // DELETE api/users/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Workcatalog>> Delete(int Id)
        {
            Workcatalog workcatalog = db.Workcatalogs.FirstOrDefault(x => x.Workcatalog_Id == Id);
            if (workcatalog == null)
            {
                return NotFound();
            }
            db.Workcatalogs.Remove(workcatalog);
            await db.SaveChangesAsync();
            return Ok(workcatalog);
        }
    }
}