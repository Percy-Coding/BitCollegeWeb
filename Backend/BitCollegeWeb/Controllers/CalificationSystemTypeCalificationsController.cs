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

        [HttpPatch("{CalificationSystemId}/TypeCalifications/{TypeCalificationId}")]
        public async Task<IActionResult> AssignTypeCalification(int CalificationSystemId, int TypeCalificationId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CalificationSystem calificationsystem = await _context.CalificationSystems.FindAsync(CalificationSystemId);
            TypeCalification typecalification = await _context.TypeCalifications.FindAsync(TypeCalificationId);

            if (calificationsystem == null)
                return NotFound();

            if (typecalification == null)
                return NotFound();

            CalificationSystemTypeCalification newAssign = new CalificationSystemTypeCalification
            {
                CalificationSystemId = CalificationSystemId,
                TypeCalificationId = TypeCalificationId,
            };

            await _context.CalificationSystemTypes.AddAsync(newAssign);
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

        // DELETE: api/CalificationSystemTypeCalifications/5
        [HttpDelete("{CalificationSystemId}/TypeCalifications/{TypeCalificationId}")]
        public async Task<IActionResult> UnAssignTypeCalification(int CalificationSystemId,int TypeCalificationId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CalificationSystemTypeCalification calificationsystemtypecalification = await _context.CalificationSystemTypes
                .Where(x => x.CalificationSystemId.Equals(CalificationSystemId))
                .Where(y => y.TypeCalificationId.Equals(TypeCalificationId))
                .FirstOrDefaultAsync();

            if (calificationsystemtypecalification == null)
                return NotFound();

            try
            {
                _context.Remove(calificationsystemtypecalification);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        private bool CalificationSystemTypeCalificationExists(int id)
        {
            return _context.CalificationSystemTypes.Any(e => e.CalificationSystemId == id);
        }
    }
}
