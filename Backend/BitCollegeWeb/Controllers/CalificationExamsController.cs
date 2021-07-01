using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.CalificationExam;

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
        public async Task<IEnumerable<CalificationExamModel>> GetCalificationExams()
        {
            var calificationexamlist = await _context.CalificationExams.ToListAsync();


            return calificationexamlist.Select(d => new CalificationExamModel
            {
                CalificationExamId = d.CalificationExamId,
                Note = d.Note
            });
        }

        // GET: api/CalificationExams/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalificationExamById(int id)
        {
            var calificationexam = await _context.CalificationExams.FindAsync(id);

            if (calificationexam == null)
                return NotFound();

            return Ok(new CalificationExamModel
            {
                CalificationExamId = calificationexam.CalificationExamId,
                Note = calificationexam.Note
            });
        }

        // PUT: api/CalificationExams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalificationExam(int id, [FromBody] UpdateCalificationExamModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest();

            var calificationexam = await _context.CalificationExams.FirstOrDefaultAsync(d => d.CalificationExamId == id);

            if (calificationexam == null)
                return NotFound();



            calificationexam.Note = model.Note;

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

        // POST: api/CalificationExams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostCalificationExam([FromBody] CreateCalificationExamModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CalificationExam calificationexam = new CalificationExam
            {
                Note = model.Note
            };
            _context.CalificationExams.Add(calificationexam);
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

        // DELETE: api/CalificationExams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalificationExam(int id)
        {
            var existingCalificationExam = await _context.CalificationExams.FindAsync(id);
            if (existingCalificationExam == null)
                return NotFound();

            try
            {
                _context.Remove(existingCalificationExam);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingCalificationExam);
        }

        private bool CalificationExamExists(int id)
        {
            return _context.CalificationExams.Any(e => e.CalificationExamId == id);
        }
    }
}
