using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Interior_decorating_company.DAL.Controllers
{
    [ApiController]
    [Route("/Product")]
    public class ProductController : ControllerBase

    {
        ApplicationContext db;
        public ProductController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await db.Products.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int Id)
        {
            Product product = await db.Products.FirstOrDefaultAsync(x => x.Item_Id == Id);
            if (product == null)
                return NotFound();
            return new ObjectResult(product);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            db.Products.Add(product);
            await db.SaveChangesAsync();
            return Ok(product);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Product>> Put(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            if (!db.Products.Any(x => x.Item_Id == product.Item_Id))
            {
                return NotFound();
            }

            db.Update(product);
            await db.SaveChangesAsync();
            return Ok(product);
        }

        // DELETE api/users/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Product>> Delete(int Id)
        {
            Product product = db.Products.FirstOrDefault(x => x.Item_Id == Id);
            if (product == null)
            {
                return NotFound();
            }
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return Ok(product);
        }
    }
}