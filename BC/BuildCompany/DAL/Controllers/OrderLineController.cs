using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Interior_decorating_company.DAL.Controllers
{
    [ApiController]
    [Route("/OrderLine")]
    public class OrderLineController : ControllerBase
    {
        ApplicationContext db;
        public OrderLineController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderLine>>> Get()
        {
            return await db.OrderLines.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderLine>> Get(int Id)
        {
            OrderLine orderLine = await db.OrderLines.FirstOrDefaultAsync(x => x.OrderLine_Id == Id);
            if (orderLine == null)
                return NotFound();
            return new ObjectResult(orderLine);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<OrderLine>> Post(OrderLine orderLine)
        {
            if (orderLine == null)
            {
                return BadRequest();
            }

            db.OrderLines.Add(orderLine);
            await db.SaveChangesAsync();
            return Ok(orderLine);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<OrderLine>> Put(OrderLine orderLine)
        {
            if (orderLine == null)
            {
                return BadRequest();
            }
            if (!db.OrderLines.Any(x => x.OrderLine_Id == orderLine.OrderLine_Id))
            {
                return NotFound();
            }

            db.Update(orderLine);
            await db.SaveChangesAsync();
            return Ok(orderLine);
        }

        // DELETE api/users/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<OrderLine>> Delete(int Id)
        {
            OrderLine orderLine = db.OrderLines.FirstOrDefault(x => x.OrderLine_Id == Id);
            if (orderLine == null)
            {
                return NotFound();
            }
            db.OrderLines.Remove(orderLine);
            await db.SaveChangesAsync();
            return Ok(orderLine);
        }
    }
}