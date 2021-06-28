using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Models.CalificationSystem;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificationSystemsController : ControllerBase
    {
        //patron de diseño singleton aplicado a nuestro context donde me ayuda a realizar cada metodo planteado

        private readonly DbContextBitCollegeWeb _context;

        public CalificationSystemsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/CalificationSystems
        [HttpGet]
        public async Task<IEnumerable<CalificationSystemModel>> GetCalificationSystems()
        {
            var CalificationSystemList = await _context.CalificationSystems.ToListAsync();

            return CalificationSystemList.Select(d => new CalificationSystemModel
            {
                CalificationSystemId = d.CalificationSystemId,
                NumberPercentage = d.NumberPercentage,

            });
        }

        // GET: api/CalificationSystems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalificationSystemById(int id)
        {
            var CalificatioSystem = await _context.CalificationSystems.FindAsync(id);

            if (CalificatioSystem == null)
                return NotFound();

            return Ok(new CalificationSystemModel
            {
                CalificationSystemId = CalificatioSystem.CalificationSystemId,
                NumberPercentage = CalificatioSystem.NumberPercentage,
            });
        }

        // PUT: api/CalificationSystems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalificationSystem(int id, [FromBody] UpdateCalificationSystemModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest();

            var CalificationSystem = await _context.CalificationSystems.FirstOrDefaultAsync(d => d.CalificationSystemId == id);

            if (CalificationSystem == null)
                return NotFound();



            CalificationSystem.NumberPercentage = model.NumberPercentage;

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

        // POST: api/CalificationSystems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostCalificationSystem([FromBody] CreateCalificationSystemModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CalificationSystem calificationSystem = new CalificationSystem
            {
                NumberPercentage = model.NumberPercentage
            };
            _context.CalificationSystems.Add(calificationSystem);
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

        // DELETE: api/CalificationSystems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalificationSystem(int id)
        {
            var existingCalificationSystem = await _context.CalificationSystems.FindAsync(id);
            if (existingCalificationSystem == null)
                return NotFound();

            try
            {
                _context.Remove(existingCalificationSystem);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingCalificationSystem);
        }

        private bool CalificationSystemExists(int id)
        {
            return _context.CalificationSystems.Any(e => e.CalificationSystemId == id);
        }
    }
}
