using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.Exam;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public ExamsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/Exams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> GetExams()
        {
            return await _context.Exams.ToListAsync();
        }

        // GET: api/Exams/5
        [HttpGet("Section/{SectionId}/Exams")]
        public async Task<ActionResult<Exam>> GetExam(int SectionId)
        {
            IEnumerable<Exam> examList = await _context.Exams.ToListAsync();

            var examListBySectionId = examList.ToList().Where(d => d.SectionId == SectionId);

            if (examListBySectionId.Count() > 0)
            {
                return Ok(examListBySectionId.Select(d => new ExamModel
                {
                    ExamId = d.ExamId,
                    Title = d.Title,
                    DateStart = d.DateStart,
                    StartTime = d.StartTime,
                    FinishTime = d.FinishTime,
                    Description = d.Description,
                    SectionId = d.SectionId,
                    CalificationExamId = d.CalificationExamId,
                    PendingComplete = d.PendingComplete,
                    SentNotSent = d.SentNotSent

                }));
            }
            else
            {
                return Ok("No hay examenes para esta Section.");
            }
        }


        // POST: api/Exams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Section/{SectionId}/Exams")]
        public async Task<ActionResult<Exam>> PostExam(int SectionId ,[FromBody] CreateExamModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Section section = await _context.Sections.FindAsync(SectionId);

            if (section == null)
                return NotFound();

            Exam exam = new Exam
            {
                Title = model.Title,
                DateStart = model.DateStart,
                StartTime = model.StartTime,
                FinishTime = model.FinishTime,
                Description = model.Description,
                SectionId = model.SectionId,
                CalificationExamId = model.CalificationExamId,
                PendingComplete = model.PendingComplete,
                SentNotSent = model.SentNotSent
            };
            _context.Exams.Add(exam);
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

        // DELETE: api/Exams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var existingExam = await _context.Exams.FindAsync(id);
            if (existingExam == null)
                return NotFound();

            try
            {
                _context.Remove(existingExam);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingExam);
        }

        private bool ExamExists(int id)
        {
            return _context.Exams.Any(e => e.ExamId == id);
        }
    }
}
