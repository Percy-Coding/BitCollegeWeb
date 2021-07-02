using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.Section;
using BitCollegeWeb.Models.Student;

namespace BitCollegeWeb.Controllers
{
    [Route("api")]
    [ApiController]
    public class StudentSectionsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public StudentSectionsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/StudentSections
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<StudentSection>>> GetStudentSections()
        //{
        //    return await _context.StudentSections.ToListAsync();
        //}

        // GET: api/StudentSections/5
        [HttpGet("Student/{StudentId}/Sections")]
        public async Task<IEnumerable<SectionModel>> GetSectionsByStudentId(int StudentId)
        {
            var studentsections = await _context.StudentSections
               .Include(st => st.Student)
               .Include(st => st.Section)
               .Where(x => x.StudentId.Equals(StudentId))
               .ToListAsync();

            if (studentsections == null)
                return null;

            return studentsections.Select(x => new SectionModel
            {
                SectionId = x.SectionId,
                SectionCode = x.Section.SectionCode,
                ProgrammingStudyId = x.Section.ProgrammingStudyId,
                NumberRecordings = x.Section.NumberRecordings,
                NumberStudentsEnroll = x.Section.NumberStudentsEnroll,
                Vacancies = x.Section.Vacancies

            });
        }

        [HttpGet("Section/{SectionId}/Students")]
        public async Task<IEnumerable<StudentModel>> GetStudentsBySectionId(int SectionId)
        {
            var studentsections = await _context.StudentSections
               .Include(st => st.Student)
               .Include(st => st.Section)
               .Where(x => x.SectionId.Equals(SectionId))
               .ToListAsync();

            if (studentsections == null)
                return null;

            return studentsections.Select(x => new StudentModel
            {
                StudentId = x.StudentId,
                StudentExperienceId = x.Student.StudentExperienceId
            });
        }

        [HttpPatch("Section/{SectionId}/Student/{StudentId}")]
        public async Task<IActionResult> AssignStudent(int SectionId, int StudentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Section section = await _context.Sections.FindAsync(SectionId);
            Student student = await _context.Students.FindAsync(StudentId);

            if (section == null)
                return NotFound();

            if (student == null)
                return NotFound();

            StudentSection newAssign = new StudentSection
            {
                SectionId = SectionId,
                StudentId = StudentId,
            };

            await _context.StudentSections.AddAsync(newAssign);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // DELETE: api/StudentSections/5
        [HttpDelete("Section/{SectionId}/Student/{StudentId}")]
        public async Task<IActionResult> UnAssignStudent(int SectionId, int StudentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StudentSection studentsection = await _context.StudentSections
                .Where(x => x.SectionId.Equals(SectionId))
                .Where(y => y.StudentId.Equals(StudentId))
                .FirstOrDefaultAsync();

            if (studentsection == null)
                return NotFound();

            try
            {
                _context.Remove(studentsection);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        private bool StudentSectionExists(int id)
        {
            return _context.StudentSections.Any(e => e.StudentId == id);
        }
    }
}
