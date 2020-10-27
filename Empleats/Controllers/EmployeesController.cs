using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Empleats.Data;
using Empleats.Models;


namespace Empleats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmpleatsContext _context;

        public EmployeesController(EmpleatsContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]                        //Dame todos los empleados
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await _context.Employee.ToListAsync();
        }


        /*EXERCICI 1    --Deixem comentats els altres HttpGet perque no hi hagi ambigüetats
         Exemple: https://localhost:44317/api/Employees/Marc
        [HttpGet("{name}")]   
        public string GetEmployee (string name)
        {                            
            if (name is null)
            {
                return "Hola mundo";
            }
            else
            {
                return "HOLA " + name;
            }
               
        }
        */


            // GET: api/Employees/5      La id en este caso es el último numero de la url (ejemplo de id:2 --> localhost:44317/api/Employees/2
        [HttpGet("{id}")]                // Dame todos los empleados por id
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);   //_context.Employee.**** funciones que se encuentran en el DBcontext (Ctrl + click)

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }
        


        // PUT: api/Employees/5       //Hazme una edición del empleado con id * 
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]          //Guardame este empleado que te estoy enviando
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            if(employee.Name.ToLower() == "francisco")
            {
                employee.Name = "PACO";
            }


            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]     //Bórrame este que tiene id *
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }
    }
}
