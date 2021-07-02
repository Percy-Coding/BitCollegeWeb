using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.Assignment;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public AssignmentsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/Assignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignments()
        {
            return await _context.Assignments.ToListAsync();
        }

        // GET: api/Assignments/5
        [HttpGet("Section/{SectionId}/Assignments")]
        public async Task<ActionResult<Assignment>> GetAssignmentsBySectionId(int SectionId)
        {
            IEnumerable<Assignment> assignmentList = await _context.Assignments.ToListAsync();

            var assignmentListBySectionId = assignmentList.ToList().Where(d => d.SectionId == SectionId);

            if (assignmentListBySectionId.Count() > 0)
            {
                return Ok(assignmentListBySectionId.Select(d => new AssignmentModel
                {
                    AssignmentId = d.AssignmentId,
                    Title = d.Title,
                    DateLimit = d.DateLimit,
                    SectionId = d.SectionId,
                    DocumentLink = d.DocumentLink,
                    ShippingDate = d.ShippingDate,
                    PendingComplete = d.PendingComplete,
                    SentNotSent = d.SentNotSent,
                    CalificationAssignmentId = d.CalificationAssignmentId

                }));
            }
            else
            {
                return Ok("No hay asignaciones para esta Section.");
            }
        }

        // POST: api/Assignments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Section/{SectionId}/Assignments")]
        public async Task<ActionResult<Assignment>> PostAssignment(int SectionId ,[FromBody] CreateAssignmentModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Section section = await _context.Sections.FindAsync(SectionId);

            if (section == null)
                return NotFound();

            Assignment assignment = new Assignment
            {
                Title = model.Title,
                DateLimit = model.DateLimit,
                SectionId = model.SectionId,
                DocumentLink = model.DocumentLink,
                ShippingDate = model.ShippingDate,
                PendingComplete = model.PendingComplete,
                SentNotSent = model.SentNotSent,
                CalificationAssignmentId = model.CalificationAssignmentId
            };
            _context.Assignments.Add(assignment);
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

        // DELETE: api/Assignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var existingAssignment = await _context.Assignments.FindAsync(id);
            if (existingAssignment == null)
                return NotFound();

            try
            {
                _context.Remove(existingAssignment);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingAssignment);
        }
    }
}
