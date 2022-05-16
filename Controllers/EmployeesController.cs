#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketElevatorsApi.Data;
using RocketElevatorsApi.Models;

namespace RocketElevatorsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await _context.employees.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(long id)
        {
            var employee = await _context.employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutEmployee(long id, Employee employee)
        // {
        //     if (id != employee.id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(employee).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!EmployeeExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // api/employees/login/{email}
        [HttpGet("login/{email}")]
        public async Task<ActionResult<Employee>> loginEmployee(string email)
        {
            var allEmployees = await _context.employees.ToListAsync();
            var loginEmployee = allEmployees.Where(u => u.email == email);
            if (loginEmployee.Count() > 0)
            {
                var employee = await _context.employees.FindAsync(loginEmployee.First().id);
                if (employee != null)
                {
                    return employee;
                }
            }
            return Unauthorized();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        // {
        //     _context.employees.Add(employee);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetEmployee", new { id = employee.id }, employee);
        // }

        // DELETE: api/Employees/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteEmployee(long id)
        // {
        //     var employee = await _context.employees.FindAsync(id);
        //     if (employee == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.employees.Remove(employee);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        private bool EmployeeExists(long id)
        {
            return _context.employees.Any(e => e.id == id);
        }
    }
}
