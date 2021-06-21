using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Data;
using BitCollegeWeb.Entities;
using BitCollegeWeb.Models.ProgrammingStudy;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingStudiesController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public ProgrammingStudiesController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/ProgrammingStudies
        [HttpGet]
        public async Task<IEnumerable<ProgrammingStudyModel>> GetProgrammingStudies()
        {
            var ProgrammingStudyList = await _context.ProgrammingStudies.ToListAsync();

            return ProgrammingStudyList.Select(d => new ProgrammingStudyModel
            {
                ProgrammingStudyId = d.ProgrammingStudyId,
                Name = d.Name,
                TypeStudyId = d.TypeStudyId,
                CalificationSystemId = d.CalificationSystemId,
                TypeProgrammingClassId = d.TypeProgrammingClassId,
            });
        }

        // GET: api/ProgrammingStudies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgrammingStudyById(int id)
        {
            var programmingstudy = await _context.ProgrammingStudies.FindAsync(id);

            if (programmingstudy == null)
                return NotFound();

            return Ok(new ProgrammingStudyModel
            {
                ProgrammingStudyId = programmingstudy.ProgrammingStudyId,
                Name = programmingstudy.Name,
                TypeStudyId = programmingstudy.TypeStudyId,
                CalificationSystemId = programmingstudy.CalificationSystemId,
                TypeProgrammingClassId = programmingstudy.TypeProgrammingClassId,
            });

        }

        // PUT: api/ProgrammingStudies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProgrammingStudy(int id, ProgrammingStudy programmingStudy)
        //{
        //    if (id != programmingStudy.ProgrammingStudyId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(programmingStudy).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProgrammingStudyExists(id))
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

        // POST: api/ProgrammingStudies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostProgrammingStudy([FromBody] CreateProgrammingStudyModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ProgrammingStudy programmingstudy = new ProgrammingStudy
            {
                Name = model.Name,
                TypeStudyId = model.TypeStudyId,
                CalificationSystemId = model.CalificationSystemId,
                TypeProgrammingClassId = model.TypeProgrammingClassId,

            };
            _context.ProgrammingStudies.Add(programmingstudy);
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

        // DELETE: api/ProgrammingStudies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgrammingStudy(int id)
        {
            var existingProgrammingStudy = await _context.ProgrammingStudies.FindAsync(id);
            if (existingProgrammingStudy == null)
                return NotFound();

            try
            {
                _context.Remove(existingProgrammingStudy);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingProgrammingStudy);
        }

        private bool ProgrammingStudyExists(int id)
        {
            return _context.ProgrammingStudies.Any(e => e.ProgrammingStudyId == id);
        }
    }
}
