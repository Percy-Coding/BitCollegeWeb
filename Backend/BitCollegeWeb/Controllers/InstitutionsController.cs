using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.Institution;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public InstitutionsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/Institutions
        [HttpGet]
        public async Task<IEnumerable<InstitutionModel>> GetInstitutions()
        {
            var InstitutionList = await _context.Institutions.ToListAsync();


            return InstitutionList.Select(d => new InstitutionModel
            {
                InstitutionId = d.InstitutionId,
                Name = d.Name,
                Description = d.Description

            });
        }

        // GET: api/Institutions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstitutionById(int id)
        {
            var Institution = await _context.Institutions.FindAsync(id);

            if (Institution == null)
                return NotFound();

            return Ok(new InstitutionModel
            {
                InstitutionId = Institution.InstitutionId,
                Name = Institution.Name,
                Description = Institution.Description
            });
        }

        // PUT: api/Institutions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutInstitution(int id, Institution institution)
        //{
        //    if (id != institution.InstitutionId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(institution).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!InstitutionExists(id))
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

        // POST: api/Institutions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostInstitution([FromBody] CreateInstitutionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Institution institution = new Institution
            {
                Name = model.Name,
                Description = model.Description
            };
            _context.Institutions.Add(institution);
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

        // DELETE: api/Institutions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitution(int id)
        {
            var existingInstituion = await _context.Institutions.FindAsync(id);
            if (existingInstituion == null)
                return NotFound();

            try
            {
                _context.Remove(existingInstituion);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingInstituion);
        }

        private bool InstitutionExists(int id)
        {
            return _context.Institutions.Any(e => e.InstitutionId == id);
        }
    }
}
