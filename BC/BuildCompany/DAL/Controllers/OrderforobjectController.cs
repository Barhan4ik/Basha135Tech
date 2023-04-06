using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Interior_decorating_company.DAL.Controllers
{
    [ApiController]
    [Route("/Orderforobject")]
    public class OrderforobjectController : ControllerBase

    {
        ApplicationContext db;
        public OrderforobjectController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orderforobject>>> Get()
        {
            return await db.Orderforobjects.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orderforobject>> Get(int Id)
        {
            Orderforobject orderforobject = await db.Orderforobjects.FirstOrDefaultAsync(x => x.Order_number_Id == Id);
            if (orderforobject == null)
                return NotFound();
            return new ObjectResult(orderforobject);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Orderforobject>> Post(Orderforobject orderforobject)
        {
            if (orderforobject == null)
            {
                return BadRequest();
            }

            db.Orderforobjects.Add(orderforobject);
            await db.SaveChangesAsync();
            return Ok(orderforobject);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Orderforobject>> Put(Orderforobject orderforobject)
        {
            if (orderforobject == null)
            {
                return BadRequest();
            }
            if (!db.Orderforobjects.Any(x => x.Order_number_Id == orderforobject.Order_number_Id))
            {
                return NotFound();
            }

            db.Update(orderforobject);
            await db.SaveChangesAsync();
            return Ok(orderforobject);
        }

        // DELETE api/users/5
        [HttpDelete("{number}")]
        public async Task<ActionResult<Orderforobject>> Delete(int Id)
        {
            Orderforobject orderforobject = db.Orderforobjects.FirstOrDefault(x => x.Order_number_Id == Id);
            if (orderforobject == null)
            {
                return NotFound();
            }
            db.Orderforobjects.Remove(orderforobject);
            await db.SaveChangesAsync();
            return Ok(orderforobject);
        }
    }
}