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
    [Route("api/[controller]")]
    [ApiController]
    public class TypeSectionsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public TypeSectionsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/TypeSections
        [HttpGet]
        public async Task<IEnumerable<TypeSectionModel>> GetTypeSections()
        {
            var TypeSectionList = await _context.TypeSections.ToListAsync();

            return TypeSectionList.Select(d => new TypeSectionModel
            {
                TypeSectionId = d.TypeSectionId,
                Name = d.Name

            });
        }

        // GET: api/TypeSections/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeSectionById(int id)
        {
            var typesection = await _context.TypeSections.FindAsync(id);

            if (typesection == null)
                return NotFound();

            return Ok(new TypeSectionModel
            {
                TypeSectionId = typesection.TypeSectionId,
                Name = typesection.Name
            });
        }

        // PUT: api/TypeSections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTypeSection(int id, TypeSection typeSection)
        //{
        //    if (id != typeSection.TypeSectionId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(typeSection).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TypeSectionExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //POST: api/TypeSections
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostTypeSection([FromBody] CreateTypeSectionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TypeSection typesection = new TypeSection
            {
                Name = model.Name,
            };
            _context.TypeSections.Add(typesection);
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

        // DELETE: api/TypeSections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeSection(int id)
        {
            var existingtypeSection = await _context.TypeSections.FindAsync(id);
            if (existingtypeSection == null)
                return NotFound();

            try
            {
                _context.Remove(existingtypeSection);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingtypeSection);
        }

        private bool TypeSectionExists(int id)
        {
            return _context.TypeSections.Any(e => e.TypeSectionId == id);
        }
    }
}
