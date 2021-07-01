using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSectionsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public StudentSectionsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/StudentSections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentSection>>> GetStudentSections()
        {
            return await _context.StudentSections.ToListAsync();
        }

        // GET: api/StudentSections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentSection>> GetStudentSection(int id)
        {
            var studentSection = await _context.StudentSections.FindAsync(id);

            if (studentSection == null)
            {
                return NotFound();
            }

            return studentSection;
        }

        // PUT: api/StudentSections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentSection(int id, StudentSection studentSection)
        {
            if (id != studentSection.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(studentSection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentSectionExists(id))
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

        // POST: api/StudentSections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentSection>> PostStudentSection(StudentSection studentSection)
        {
            _context.StudentSections.Add(studentSection);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentSectionExists(studentSection.StudentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentSection", new { id = studentSection.StudentId }, studentSection);
        }

        // DELETE: api/StudentSections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentSection(int id)
        {
            var studentSection = await _context.StudentSections.FindAsync(id);
            if (studentSection == null)
            {
                return NotFound();
            }

            _context.StudentSections.Remove(studentSection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentSectionExists(int id)
        {
            return _context.StudentSections.Any(e => e.StudentId == id);
        }
    }
}
