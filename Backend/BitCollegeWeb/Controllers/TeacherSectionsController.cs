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
using BitCollegeWeb.Models.Teacher;

namespace BitCollegeWeb.Controllers
{
    [Route("api")]
    [ApiController]
    public class TeacherSectionsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public TeacherSectionsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/TeacherSections
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TeacherSection>>> GetTeacherSections()
        //{
        //    return await _context.TeacherSections.ToListAsync();
        //}

        // GET: api/TeacherSections/5
        [HttpGet("Teacher/{TeacherId}/Sections")]
        public async Task<IEnumerable<SectionModel>> GetSectionsByTeacherId(int TeacherId)
        {
            var teachersections = await _context.TeacherSections
               .Include(st => st.Teacher)
               .Include(st => st.Section)
               .Where(x => x.TeacherId.Equals(TeacherId))
               .ToListAsync();

            if (teachersections == null)
                return null;

            return teachersections.Select(x => new SectionModel
            {
                SectionId = x.SectionId,
                SectionCode = x.Section.SectionCode,
                ProgrammingStudyId = x.Section.ProgrammingStudyId,
                NumberRecordings = x.Section.NumberRecordings,
                NumberStudentsEnroll = x.Section.NumberStudentsEnroll,
                Vacancies = x.Section.Vacancies

            });
        }

        [HttpGet("Section/{SectionId}/Teachers")]
        public async Task<IEnumerable<TeacherModel>> GetTeachersBySectionId(int SectionId)
        {
            var teachersections = await _context.TeacherSections
               .Include(st => st.Teacher)
               .Include(st => st.Section)
               .Where(x => x.SectionId.Equals(SectionId))
               .ToListAsync();

            if (teachersections == null)
                return null;

            return teachersections.Select(x => new TeacherModel
            {
                TeacherId = x.TeacherId,
                TeacherExperienceId = x.Teacher.TeacherExperienceId

            });
        }

        [HttpPatch("Section/{SectionId}/Teacher/{TeacherId}")]
        public async Task<IActionResult> AssignTeacher(int SectionId, int TeacherId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Section section = await _context.Sections.FindAsync(SectionId);
            Teacher teacher = await _context.Teachers.FindAsync(TeacherId);

            if (section == null)
                return NotFound();

            if (teacher == null)
                return NotFound();

            TeacherSection newAssign = new TeacherSection
            {
                SectionId = SectionId,
                TeacherId = TeacherId,
            };

            await _context.TeacherSections.AddAsync(newAssign);
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

        // DELETE: api/TeacherSections/5
        [HttpDelete("Section/{SectionId}/Teacher/{TeacherId}")]
        public async Task<IActionResult> UnAssignTeacher(int SectionId,int TeacherId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TeacherSection teachersection = await _context.TeacherSections
                .Where(x => x.SectionId.Equals(SectionId))
                .Where(y => y.TeacherId.Equals(TeacherId))
                .FirstOrDefaultAsync();

            if (teachersection == null)
                return NotFound();

            try
            {
                _context.Remove(teachersection);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        private bool TeacherSectionExists(int id)
        {
            return _context.TeacherSections.Any(e => e.TeacherId == id);
        }
    }
}
