using DMAWS_T2204M_Thuy.DTOs;
using DMAWS_T2204M_Thuy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMAWS_T2204M_Thuy.Controllers
{
    [Route("api/employee")]

    [ApiController]
    public class EmployeesController : Controller
    {

        private readonly ExamContext _context;

        public EmployeesController(ExamContext context)
        {
            _context = context;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        async public Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                var dcs = await _context.Employees.ToListAsync();
                return Ok(dcs);
            }
            var dc = await _context.Employees.FindAsync(id);

            if (dc == null) { return NotFound(); }
            return Ok(dc);
        }

        // POST api/<CategoryController>
        [HttpPost, Route("create")]
        async public Task<IActionResult> Create(EmployeeDTO data)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(new Project { EmployeeName = data.EmployeeName, EmployeeDOB = data.EmployeeDOB, EmployeeDepartment = data.EmployeeDepartment });
                await _context.SaveChangesAsync();
                return Ok("created");
            }
            return BadRequest();
        }

        // PUT api/<CategoryController>/5
        [HttpPut, Route("update")]
        async public Task<IActionResult> Update(Project data)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Update(data);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete, Route("delete")]
        async public Task<IActionResult> Delete(int id)
        {
            var a = _context.Projects.Find(id);
            if (a != null)
            {
                _context.Projects.Remove(a);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }
    }
}
