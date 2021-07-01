using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.CalificationAssignment;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificationAssignmentsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public CalificationAssignmentsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/CalificationAssignments
        [HttpGet]
        public async Task<IEnumerable<CalificationAssignmentModel>> GetCalificationAssignments()
        {
            var CalificationAssignmentList = await _context.CalificationAssignments.ToListAsync();


            return CalificationAssignmentList.Select(d => new CalificationAssignmentModel
            {
                CalificationAssignmentId = d.CalificationAssignmentId,
                Note = d.Note,
                Comment = d.Comment,
                CommentPublished = d.CommentPublished
            });
        }

        // GET: api/CalificationAssignments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalificationAssignmentById(int id)
        {
            var CalificationAssignment = await _context.CalificationAssignments.FindAsync(id);

            if (CalificationAssignment == null)
                return NotFound();

            return Ok(new CalificationAssignmentModel
            {
                CalificationAssignmentId = CalificationAssignment.CalificationAssignmentId,
                Note = CalificationAssignment.Note,
                Comment = CalificationAssignment.Comment,
                CommentPublished = CalificationAssignment.CommentPublished
            });
        }

        // PUT: api/CalificationAssignments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalificationAssignment(int id, [FromBody] UpdateCalificationAssignmentModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest();

            var calificationassignment = await _context.CalificationAssignments.FirstOrDefaultAsync(d => d.CalificationAssignmentId == id);

            if (calificationassignment == null)
                return NotFound();



            calificationassignment.Note = model.Note;
            calificationassignment.Comment = model.Comment;
            calificationassignment.CommentPublished = model.CommentPublished;

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

        // POST: api/CalificationAssignments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostCalificationAssignment([FromBody] CreateCalificationAssignmentModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CalificationAssignment calificationAssignment = new CalificationAssignment
            {

                Note = model.Note,
                Comment = model.Comment,
                CommentPublished = model.CommentPublished
            };
            _context.CalificationAssignments.Add(calificationAssignment);
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

        // DELETE: api/CalificationAssignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalificationAssignment(int id)
        {
            var existingCalificationAssignment = await _context.CalificationAssignments.FindAsync(id);
            if (existingCalificationAssignment == null)
                return NotFound();

            try
            {
                _context.Remove(existingCalificationAssignment);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingCalificationAssignment);
        }

        private bool CalificationAssignmentExists(int id)
        {
            return _context.CalificationAssignments.Any(e => e.CalificationAssignmentId == id);
        }
    }
}
