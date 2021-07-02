using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Models.Section;

namespace BitCollegeWeb.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public SectionsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/Sections
        [HttpGet("Sections")]
        public async Task<IEnumerable<SectionModel>> GetSections()
        {
            var SectionList = await _context.Sections.ToListAsync();


            return SectionList.Select(d => new SectionModel
            {
                SectionId = d.SectionId,
                SectionCode = d.SectionCode,
                ProgrammingStudyId = d.ProgrammingStudyId,
                NumberRecordings = d.NumberRecordings,
                NumberStudentsEnroll = d.NumberStudentsEnroll,
                Vacancies = d.Vacancies

            });
        }

        // GET: api/Sections/5
        [HttpGet("Section/{id}")]
        public async Task<IActionResult> GetSectionById(int id)
        {
            var section = await _context.Sections.FindAsync(id);

            if (section == null)
                return NotFound();

            return Ok(new SectionModel
            {
                SectionId = section.SectionId,
                SectionCode = section.SectionCode,
                ProgrammingStudyId = section.ProgrammingStudyId,
                NumberRecordings = section.NumberRecordings,
                NumberStudentsEnroll = section.NumberStudentsEnroll,
                Vacancies = section.Vacancies
            });
        }

        // GET: api/Sections/5
        [HttpGet("ProgrammingStudy/{ProgrammingStudyId}/Section")]
        public async Task<ActionResult<Section>> GetSectionByProgrammingStudyId(int ProgrammingStudyId)
        {
            IEnumerable<Section> sectionList = await _context.Sections.ToListAsync();

            var SectionListByProgrammingStudyId = sectionList.ToList().Where(d => d.ProgrammingStudyId == ProgrammingStudyId);

            if (SectionListByProgrammingStudyId.Count() > 0)
            {
                return Ok(SectionListByProgrammingStudyId.Select(d => new SectionModel
                {
                    SectionId = d.SectionId,
                    SectionCode = d.SectionCode,
                    ProgrammingStudyId = d.ProgrammingStudyId,
                    NumberRecordings = d.NumberRecordings,
                    NumberStudentsEnroll = d.NumberStudentsEnroll,
                    Vacancies = d.Vacancies

                }));
            }
            else
            {
                return Ok("No hay section(s) para el ProgrammingStudy.");
            }
        }

        // PUT: api/Sections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSection(int id, [FromBody] UpdateSectionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest();

            var section = await _context.Sections.FirstOrDefaultAsync(d => d.SectionId == id);

            if (section == null)
                return NotFound();

            section.NumberRecordings = model.NumberRecordings;
            section.NumberStudentsEnroll = model.NumberStudentsEnroll;
            section.Vacancies = model.Vacancies;

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

        // POST: api/Sections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostSection([FromBody] CreateSectionModel model)
        {
            ProgrammingStudy programmingstudy = await _context.ProgrammingStudies.FindAsync(model.ProgrammingStudyId);

            if (programmingstudy == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Section section = new Section
            {
                SectionCode = model.SectionCode,
                NumberRecordings = model.NumberRecordings,
                NumberStudentsEnroll = model.NumberStudentsEnroll,
                ProgrammingStudyId = model.ProgrammingStudyId
            };
            _context.Sections.Add(section);
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

        // DELETE: api/Sections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSection(int id)
        {
            var existingSection = await _context.Sections.FindAsync(id);
            if (existingSection == null)
                return NotFound();

            try
            {
                _context.Remove(existingSection);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingSection);
        }

        private bool SectionExists(int id)
        {
            return _context.Sections.Any(e => e.SectionId == id);
        }
    }
}
