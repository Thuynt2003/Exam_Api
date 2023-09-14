using DMAWS_T2204M_Thuy.Models;
using Microsoft.AspNetCore.Mvc;
using DMAWS_T2204M_Thuy.Models;
using Microsoft.EntityFrameworkCore;
using DMAWS_T2204M_Thuy.DTOs;

namespace DMAWS_T2204M_Thuy.Controllers
{
    [Route("api/project")]

    [ApiController]
    public class ProjectsController : Controller
    {
        private readonly ExamContext  _context;

        public ProjectsController(ExamContext context)
        {
            _context = context;
        }

        // GET: api/<CategoryController>
        [HttpGet, Route("search_by_name")]
        async public Task<IActionResult> SearchByName(string  projectName)
        {
            var search = await _context.Projects.Where(n=>n.ProjectName.Equals(projectName)).ToListAsync();
            return Ok(search);
        }
        [HttpGet, Route("search_by_StartDate")]
        async public Task<IActionResult> SearchByStartDate(DateTime startDate)
        {
            if (startDate == null)
            {
                var search = await _context.Projects.Where(n => n.ProjectStartDate.CompareTo(startDate) == 0).ToListAsync();
                return Ok(search);
            }

            return BadRequest();
        }
        [HttpGet]
        async public Task<IActionResult> Get(string? id)
        {
            if (id == null)
            {
                var dcs = await _context.Projects.ToListAsync();
                return Ok(dcs);
            }
            var dc = await _context.Projects.FindAsync(id);

            if (dc == null) { return NotFound(); }
            return Ok(dc);
        }

        // POST api/<CategoryController>
        [HttpPost, Route("create")]
        async public Task<IActionResult> Create(ProjectDTO data)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Add(new Project { ProjectName = data.ProjectName, ProjectStartDate = data.ProjectStartDate, ProjectEndDate = data.ProjectEndDate });
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
