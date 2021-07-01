using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.StudentExperience;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentExperiencesController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public StudentExperiencesController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/StudentExperiences
        [HttpGet]
        public async Task<IEnumerable<StudentExperienceModel>> GetStudentExperiences()
        {
            var StudentsExperienceList = await _context.StudentExperiences.ToListAsync();


            return StudentsExperienceList.Select(d => new StudentExperienceModel
            {
                StudentExperienceId = d.StudentExperienceId,
                DateStartProgramming = d.DateStartProgramming,
                InstitutionId = d.InstitutionId

            });
        }

        // GET: api/StudentExperiences/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentExperienceById(int id)
        {
            var studentexperience = await _context.StudentExperiences.FindAsync(id);

            if (studentexperience == null)
                return NotFound();

            return Ok(new StudentExperienceModel
            {
                StudentExperienceId = studentexperience.StudentExperienceId,
                DateStartProgramming = studentexperience.DateStartProgramming,
                InstitutionId = studentexperience.InstitutionId
            });
        }

        // PUT: api/StudentExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentExperience(int id, [FromBody] UpdateStudentExperienceModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest();

            var studentexperience = await _context.StudentExperiences.FirstOrDefaultAsync(d => d.StudentExperienceId == id);

            if (studentexperience == null)
                return NotFound();



            studentexperience.DateStartProgramming = model.DateStartProgramming;
            studentexperience.InstitutionId = model.InstitutionId;

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

        // POST: api/StudentExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostStudentExperience([FromBody] CreateStudentExperienceModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            StudentExperience studentexperience = new StudentExperience
            {
                DateStartProgramming = model.DateStartProgramming,
                InstitutionId = model.InstitutionId
            };
            _context.StudentExperiences.Add(studentexperience);
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

        // DELETE: api/StudentExperiences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentExperience(int id)
        {
            var existingStudentExperience = await _context.StudentExperiences.FindAsync(id);
            if (existingStudentExperience == null)
                return NotFound();

            try
            {
                _context.Remove(existingStudentExperience);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingStudentExperience);
        }

        private bool StudentExperienceExists(int id)
        {
            return _context.StudentExperiences.Any(e => e.StudentExperienceId == id);
        }
    }
}
