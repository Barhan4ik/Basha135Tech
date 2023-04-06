using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Interior_decorating_company.DAL.Controllers
{
    [ApiController]
    [Route("/Typeofwork")]
    public class TypeofworkController : ControllerBase

    {
        ApplicationContext db;
        public TypeofworkController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Typeofwork>>> Get()
        {
            return await db.Typeofworks.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Typeofwork>> Get(int Id)
        {
            Typeofwork typeofwork = await db.Typeofworks.FirstOrDefaultAsync(x => x.Typeofwork_Id == Id);
            if (typeofwork == null)
                return NotFound();
            return new ObjectResult(typeofwork);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Typeofwork>> Post(Typeofwork typeofwork)
        {
            if (typeofwork == null)
            {
                return BadRequest();
            }

            db.Typeofworks.Add(typeofwork);
            await db.SaveChangesAsync();
            return Ok(typeofwork);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Typeofwork>> Put(Typeofwork typeofwork)
        {
            if (typeofwork == null)
            {
                return BadRequest();
            }
            if (!db.Typeofworks.Any(x => x.Typeofwork_Id == typeofwork.Typeofwork_Id))
            {
                return NotFound();
            }

            db.Update(typeofwork);
            await db.SaveChangesAsync();
            return Ok(typeofwork);
        }

        // DELETE api/users/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Typeofwork>> Delete(int Id)
        {
            Typeofwork typeofwork = db.Typeofworks.FirstOrDefault(x => x.Typeofwork_Id == Id);
            if (typeofwork == null)
            {
                return NotFound();
            }
            db.Typeofworks.Remove(typeofwork);
            await db.SaveChangesAsync();
            return Ok(typeofwork);
        }
    }
}