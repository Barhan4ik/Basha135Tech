using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Interior_decorating_company.DAL.Controllers

{
    [ApiController]
    [Route("/Client")]
    public class ClientController : ControllerBase
    {
        ApplicationContext db;
        public ClientController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            return await db.Clients.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(int Id)
        {
            Client client = await db.Clients.FirstOrDefaultAsync(x => x.Client_Id == Id);
            if (client == null)
                return NotFound();
            return new ObjectResult(client);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Client>> Post(Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }

            db.Clients.Add(client);
            await db.SaveChangesAsync();
            return Ok(client);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Client>> Put(Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }
            if (!db.Clients.Any(x => x.Client_Id == client.Client_Id))
            {
                return NotFound();
            }

            db.Update(client);
            await db.SaveChangesAsync();
            return Ok(client);
        }

        // DELETE api/users/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Client>> Delete(int Id)
        {
            Client client = db.Clients.FirstOrDefault(x => x.Client_Id == Id);
            if (client == null)
            {
                return NotFound();
            }
            db.Clients.Remove(client);
            await db.SaveChangesAsync();
            return Ok(client);
        }
    }
}