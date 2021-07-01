using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.ExternalTool;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalToolsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public ExternalToolsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/ExternalTools
        [HttpGet]
        public async Task<IEnumerable<ExternalToolModel>> GetExternalTools()
        {
            var ExternalToolList = await _context.ExternalTools.ToListAsync();


            return ExternalToolList.Select(d => new ExternalToolModel
            {
                ExternalToolId = d.ExternalToolId,
                Name = d.Name,
                Description = d.Description

            });
        }

        // GET: api/ExternalTools/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExternalToolById(int id)
        {
            var ExternalTool = await _context.ExternalTools.FindAsync(id);

            if (ExternalTool == null)
                return NotFound();

            return Ok(new ExternalToolModel
            {
                ExternalToolId = ExternalTool.ExternalToolId,
                Name = ExternalTool.Name,
                Description = ExternalTool.Description
            });
        }

        // PUT: api/ExternalTools/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutExternalTool(int id, ExternalTool externalTool)
        //{
        //    if (id != externalTool.ExternalToolId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(externalTool).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ExternalToolExists(id))
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

        // POST: api/ExternalTools
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostExternalTool([FromBody] CreateExternalToolModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ExternalTool externalTool = new ExternalTool
            {
                Name = model.Name,
                Description = model.Description
            };
            _context.ExternalTools.Add(externalTool);
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

        // DELETE: api/ExternalTools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExternalTool(int id)
        {
            var existingexternaltool = await _context.ExternalTools.FindAsync(id);
            if (existingexternaltool == null)
                return NotFound();

            try
            {
                _context.Remove(existingexternaltool);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingexternaltool);
        }

        private bool ExternalToolExists(int id)
        {
            return _context.ExternalTools.Any(e => e.ExternalToolId == id);
        }
    }
}
