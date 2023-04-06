using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Interior_decorating_company.DAL.Controllers
{
    [ApiController]
    [Route("/Employee")]
    public class EmployeeController : ControllerBase
    {
        ApplicationContext db;
        public EmployeeController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return await db.Employees.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int Id)
        {
            Employee employee = await db.Employees.FirstOrDefaultAsync(x => x.Employee_Id == Id);
            if (employee == null)
                return NotFound();
            return new ObjectResult(employee);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            db.Employees.Add(employee);
            await db.SaveChangesAsync();
            return Ok(employee);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Employee>> Put(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            if (!db.Employees.Any(x => x.Employee_Id == employee.Employee_Id))
            {
                return NotFound();
            }

            db.Update(employee);
            await db.SaveChangesAsync();
            return Ok(employee);
        }

        // DELETE api/users/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Employee>> Delete(int Id)
        {
            Employee employee = db.Employees.FirstOrDefault(x => x.Employee_Id == Id);
            if (employee == null)
            {
                return NotFound();
            }
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
            return Ok(employee);
        }
    }
}