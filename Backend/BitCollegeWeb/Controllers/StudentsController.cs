using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.Student;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public StudentsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<IEnumerable<StudentModel>> GetStudents()
        {
            var StudentList = await _context.Students.ToListAsync();


            return StudentList.Select(d => new StudentModel
            {
                StudentId = d.StudentId,
                StudentExperienceId = d.StudentExperienceId,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Level = d.Level
            });
        }

        // GET: api/Students/5
        [HttpGet("Student/{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            return Ok(new StudentModel
            {
                StudentId = student.StudentId,
                StudentExperienceId = student.StudentExperienceId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Level = student.Level
            });
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id,[FromBody] UpdateStudentModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest();

            var student = await _context.Students.FirstOrDefaultAsync(d => d.StudentId == id);

            if (student == null)
                return NotFound();

            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            student.Level = model.Level;

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

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent([FromBody] CreateStudentModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Student student = new Student
            {
                StudentExperienceId = model.StudentExperienceId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Level = model.Level
            };
            _context.Students.Add(student);
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

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var existingStudent = await _context.Students.FindAsync(id);
            if (existingStudent == null)
                return NotFound();

            try
            {
                _context.Remove(existingStudent);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingStudent);
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
