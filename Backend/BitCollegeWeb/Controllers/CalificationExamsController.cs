using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificationExamsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public CalificationExamsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/CalificationExams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalificationExam>>> GetCalificationExams()
        {
            return await _context.CalificationExams.ToListAsync();
        }

        // GET: api/CalificationExams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalificationExam>> GetCalificationExam(int id)
        {
            var calificationExam = await _context.CalificationExams.FindAsync(id);

            if (calificationExam == null)
            {
                return NotFound();
            }

            return calificationExam;
        }

        // PUT: api/CalificationExams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalificationExam(int id, CalificationExam calificationExam)
        {
            if (id != calificationExam.CalificationExamId)
            {
                return BadRequest();
            }

            _context.Entry(calificationExam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificationExamExists(id))
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

        // POST: api/CalificationExams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CalificationExam>> PostCalificationExam(CalificationExam calificationExam)
        {
            _context.CalificationExams.Add(calificationExam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalificationExam", new { id = calificationExam.CalificationExamId }, calificationExam);
        }

        // DELETE: api/CalificationExams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalificationExam(int id)
        {
            var calificationExam = await _context.CalificationExams.FindAsync(id);
            if (calificationExam == null)
            {
                return NotFound();
            }

            _context.CalificationExams.Remove(calificationExam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalificationExamExists(int id)
        {
            return _context.CalificationExams.Any(e => e.CalificationExamId == id);
        }
    }
}
