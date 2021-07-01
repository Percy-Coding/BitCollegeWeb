using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Models.TypeStudy;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeStudiesController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public TypeStudiesController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/TypeStudies
        [HttpGet]
        public async Task<IEnumerable<TypeStudyModel>> GetTypeStudies()
        {
            var TypeStudyList = await _context.TypeStudies.ToListAsync();

            return TypeStudyList.Select(d => new TypeStudyModel
            {
                TypeStudyId = d.TypeStudyId,
                Name = d.Name,
                Description = d.Description,
            });
        }

        // GET: api/TypeStudies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeStudyById(int id)
        {
            var typestudy = await _context.TypeStudies.FindAsync(id);

            if (typestudy == null)
                return NotFound();

            return Ok(new TypeStudyModel
            {
                TypeStudyId = typestudy.TypeStudyId,
                Name = typestudy.Name,
                Description = typestudy.Description

            });
        }

        // PUT: api/TypeStudies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTypeStudy(int id, TypeStudy typeStudy)
        //{
        //    if (id != typeStudy.TypeStudyId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(typeStudy).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TypeStudyExists(id))
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

        // POST: api/TypeStudies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostTypeStudy([FromBody] CreateTypeStudyModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TypeStudy typestudy = new TypeStudy
            {
                Name = model.Name,
                Description = model.Description
            };
            _context.TypeStudies.Add(typestudy);
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

        // DELETE: api/TypeStudies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeStudy(int id)
        {
            var existingTypeStudy = await _context.TypeStudies.FindAsync(id);
            if (existingTypeStudy == null)
                return NotFound();

            try
            {
                _context.Remove(existingTypeStudy);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingTypeStudy);
        }

        private bool TypeStudyExists(int id)
        {
            return _context.TypeStudies.Any(e => e.TypeStudyId == id);
        }
    }
}
