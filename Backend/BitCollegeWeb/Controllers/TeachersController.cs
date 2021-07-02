using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.Teacher;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public TeachersController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<IEnumerable<TeacherModel>> GetTeachers()
        {
            var TeacherList = await _context.Teachers.ToListAsync();


            return TeacherList.Select(d => new TeacherModel
            {
                TeacherId = d.TeacherId,
                TeacherExperienceId = d.TeacherExperienceId,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Level = d.Level
            });
        }

        // GET: api/Teachers/5
        [HttpGet("Teacher/{id}")]
        public async Task<ActionResult<Teacher>> GetTeacherById(int id)
        {
            var student = await _context.Teachers.FindAsync(id);

            if (student == null)
                return NotFound();

            return Ok(new TeacherModel
            {
                TeacherId = student.TeacherId,
                TeacherExperienceId = student.TeacherExperienceId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Level = student.Level
            });
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(int id, [FromBody] UpdateTeacherModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest();

            var student = await _context.Teachers.FirstOrDefaultAsync(d => d.TeacherId == id);

            if (student == null)
                return NotFound();

            student.FirstName = model.FirstName;
            student.LastName = model.LastName;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(model);
        }

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher([FromBody] CreateTeacherModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Teacher teacher = new Teacher
            {
                TeacherExperienceId = model.TeacherExperienceId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Level = model.Level
            };
            _context.Teachers.Add(teacher);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(model);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var existingTeacher = await _context.Teachers.FindAsync(id);
            if (existingTeacher == null)
                return NotFound();

            try
            {
                _context.Remove(existingTeacher);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingTeacher);
        }

        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.TeacherId == id);
        }
    }
}
