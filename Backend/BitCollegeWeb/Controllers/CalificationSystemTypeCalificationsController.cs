using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.TypeCalification;

namespace BitCollegeWeb.Controllers
{
    [Route("api/CalificationSystem")]
    [ApiController]
    public class CalificationSystemTypeCalificationsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public CalificationSystemTypeCalificationsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/CalificationSystemTypeCalifications
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CalificationSystemTypeCalification>>> GetCalificationSystemTypes()
        //{
        //    return await _context.CalificationSystemTypes.ToListAsync();
        //}

        // GET: api/CalificationSystemTypeCalifications/5
        [HttpGet("{CalificationSystemId}/TypeCalifications")]
        public async Task<IEnumerable<TypeCalificationModel>> GetTypeCalificationByCalificationSystemId(int CalificationSystemId)
        {
            var calificationsystemtypecalifications = await _context.CalificationSystemTypes
               .Include(cstc => cstc.CalificationSystem)
               .Include(cstc => cstc.TypeCalification)
               .Where(x => x.CalificationSystemId.Equals(CalificationSystemId))
               .ToListAsync();

            if (calificationsystemtypecalifications == null)
                return null;

            return calificationsystemtypecalifications.Select(x => new TypeCalificationModel
            {
                TypeCalificationId = x.TypeCalificationId,
                Name = x.TypeCalification.Name

            });
        }

        // PUT: api/CalificationSystemTypeCalifications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalificationSystemTypeCalification(int id, CalificationSystemTypeCalification calificationSystemTypeCalification)
        {
            if (id != calificationSystemTypeCalification.CalificationSystemId)
            {
                return BadRequest();
            }

            _context.Entry(calificationSystemTypeCalification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificationSystemTypeCalificationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CalificationSystemTypeCalifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CalificationSystemTypeCalification>> PostCalificationSystemTypeCalification(CalificationSystemTypeCalification calificationSystemTypeCalification)
        {
            _context.CalificationSystemTypes.Add(calificationSystemTypeCalification);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CalificationSystemTypeCalificationExists(calificationSystemTypeCalification.CalificationSystemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCalificationSystemTypeCalification", new { id = calificationSystemTypeCalification.CalificationSystemId }, calificationSystemTypeCalification);
        }

        // DELETE: api/CalificationSystemTypeCalifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalificationSystemTypeCalification(int id)
        {
            var calificationSystemTypeCalification = await _context.CalificationSystemTypes.FindAsync(id);
            if (calificationSystemTypeCalification == null)
            {
                return NotFound();
            }

            _context.CalificationSystemTypes.Remove(calificationSystemTypeCalification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalificationSystemTypeCalificationExists(int id)
        {
            return _context.CalificationSystemTypes.Any(e => e.CalificationSystemId == id);
        }
    }
}
