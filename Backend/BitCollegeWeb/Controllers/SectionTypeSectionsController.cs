using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Data;
using BitCollegeWeb.Entities;
using BitCollegeWeb.Models.TypeSection;

namespace BitCollegeWeb.Controllers
{
    [Route("api/Section")]
    [ApiController]
    public class SectionTypeSectionsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public SectionTypeSectionsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/SectionTypeSections/5
        [HttpGet("{SectionId}/Typesections")]
        public async Task<IEnumerable<TypeSectionModel>> GetTypeSectionsBySectionId(int SectionId)
        {
            var sectiontypesections = await _context.SectionTypes
               .Include(st => st.Section)
               .Include(st => st.TypeSection)
               .Where(x => x.SectionId.Equals(SectionId))
               .ToListAsync();

            if (sectiontypesections == null)
                return null;

            return sectiontypesections.Select(x => new TypeSectionModel
            {
                TypeSectionId = x.TypeSectionId,
                Name = x.TypeSection.Name

            });

        }

        [HttpPatch("{SectionId}/TypeSections/{TypeSectionId}")]
        public async Task<IActionResult> AssignTypeSection(int SectionId, int TypeSectionId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Section section = await _context.Sections.FindAsync(SectionId);
            TypeSection typesection = await _context.TypeSections.FindAsync(TypeSectionId);

            if (section == null)
                return NotFound();

            if (typesection == null)
                return NotFound();

            SectionTypeSection newAssign = new SectionTypeSection
            {
                SectionId = SectionId,
                TypeSectionId = TypeSectionId,
            };

            await _context.SectionTypes.AddAsync(newAssign);
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

        // DELETE: api/SectionTypeSections/5
        [HttpDelete("{SectionId}/TypeSections/{TypeSectionId}")]
        public async Task<IActionResult> UnAssignTypeSection(int SectionId,int TypeSectionId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            SectionTypeSection sectiontypesection = await _context.SectionTypes
                .Where(x => x.SectionId.Equals(SectionId))
                .Where(y => y.TypeSectionId.Equals(TypeSectionId))
                .FirstOrDefaultAsync();

            if (sectiontypesection == null)
                return NotFound();

            try
            {
                _context.Remove(sectiontypesection);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();

        }

        private bool SectionTypeSectionExists(int id)
        {
            return _context.SectionTypes.Any(e => e.SectionId == id);
        }
    }
}
