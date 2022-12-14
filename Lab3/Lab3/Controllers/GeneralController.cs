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
        private readonly EmployeeContext _сontext;


        public GeneralController(EmployeeContext сontext)
        {
            _сontext = сontext;
        }
        //GET
        [HttpGet("GetFull")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            if (_сontext.Employees == null)
            {
                return NotFound();
            }
            return await _сontext.Employees.ToListAsync();
        }

        //GET ID
        [HttpGet("Employee/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            if (_сontext.Employees == null)
            {
                return NotFound();
            }
            var employee = await _сontext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }
        //GET W_ID
        [HttpGet("Catalog/{id}")]
        public async Task<ActionResult<Catalog>> GetCatalog(int id)
        {
            if (_сontext.Catalogs == null)
            {
                return NotFound();
            }
            var catalog = await _сontext.Catalogs.FindAsync(id);
            if (catalog == null)
            {
                return NotFound();
            }

            return catalog;
        }
        //POST 
        [HttpPost("Employee")]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _сontext.Employees.Add(employee);
            await _сontext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }
        [HttpPost("Catalog")]
        public async Task<ActionResult<Catalog>> PostCatalog(Catalog catalog)
        {
            _сontext.Catalogs.Add(catalog);
            await _сontext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = catalog.Id }, catalog);
        }
        [HttpPut("Employee/{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpPut("Catalog/{id}")]
        public async Task<IActionResult> PutCatalog(int id, Catalog catalog)
        {
            if (id != catalog.Id)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("Employee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (_сontext.Employees == null)
            {
                return NotFound();
            }
            var employee = await _сontext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _сontext.Employees.Remove(employee);
            await _сontext.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("Catalog/{id}")]
        public async Task<IActionResult> DeleteCatalog(int id)
        {
            if (_сontext.Catalogs == null)
            {
                return NotFound();
            }
            var catalog = await _сontext.Catalogs.FindAsync(id);
            if (catalog == null)
            {
                return NotFound();
            }

            _сontext.Catalogs.Remove(catalog);
            await _сontext.SaveChangesAsync();

            return NoContent();
        }
    }
}
