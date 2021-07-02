using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.TeacherExperience;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherExperiencesController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public TeacherExperiencesController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/TeacherExperiences
        [HttpGet]
        public async Task<IEnumerable<TeacherExperienceModel>> GetTeacherExperiences()
        {
            var TeacherExperienceList = await _context.TeacherExperiences.ToListAsync();


            return TeacherExperienceList.Select(d => new TeacherExperienceModel
            {
                TeacherExperienceId = d.TeacherExperienceId,
                DateStartProgramming = d.DateStartProgramming,
                Position = d.Position,
                CompanyId = d.CompanyId,

            });
        }

        // GET: api/TeacherExperiences/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherExperienceById(int id)
        {
            var teacherexperience = await _context.TeacherExperiences.FindAsync(id);

            if (teacherexperience == null)
                return NotFound();

            return Ok(new TeacherExperienceModel
            {
                TeacherExperienceId = teacherexperience.TeacherExperienceId,
                DateStartProgramming = teacherexperience.DateStartProgramming,
                Position = teacherexperience.Position,
                CompanyId = teacherexperience.CompanyId,
            });
        }

        // PUT: api/TeacherExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacherExperience(int id, [FromBody] UpdateTeacherExperienceModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest();

            var teacherexperience = await _context.TeacherExperiences.FirstOrDefaultAsync(d => d.TeacherExperienceId == id);

            if (teacherexperience == null)
                return NotFound();



            teacherexperience.DateStartProgramming = model.DateStartProgramming;
            teacherexperience.Position = model.Position;
            teacherexperience.CompanyId = model.CompanyId;

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

        // POST: api/TeacherExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostTeacherExperience([FromBody] CreateTeacherExperienceModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TeacherExperience teacherexperience = new TeacherExperience
            {
                DateStartProgramming = model.DateStartProgramming,
                Position = model.Position,
                CompanyId = model.CompanyId
            };
            _context.TeacherExperiences.Add(teacherexperience);
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

        // DELETE: api/TeacherExperiences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacherExperience(int id)
        {
            var existingTeacherExperience = await _context.TeacherExperiences.FindAsync(id);
            if (existingTeacherExperience == null)
                return NotFound();

            try
            {
                _context.Remove(existingTeacherExperience);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingTeacherExperience);
        }

        private bool TeacherExperienceExists(int id)
        {
            return _context.TeacherExperiences.Any(e => e.TeacherExperienceId == id);
        }
    }
}
