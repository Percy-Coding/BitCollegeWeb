using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.Evidence;

namespace BitCollegeWeb.Controllers
{
    [Route("api")]
    [ApiController]
    public class EvidencesController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public EvidencesController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/Evidences
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Evidence>>> GetEvidences()
        //{
        //    return await _context.Evidences.ToListAsync();
        //}

        // GET: api/Evidences/5
        [HttpGet("TeacherForum/{TeacherForumId}/Evidences")]
        public async Task<ActionResult<Evidence>> GetEvidencesByTeacherForumId(int TeacherForumId)
        {
            IEnumerable<Evidence> evidenceList = await _context.Evidences.ToListAsync();

            var EvidencesListByTeacherForumId = evidenceList.ToList().Where(d => d.TeacherForumId == TeacherForumId);

            if (EvidencesListByTeacherForumId.Count() > 0)
            {
                return Ok(EvidencesListByTeacherForumId.Select(d => new EvidenceModel
                {
                    EvidenceId = d.EvidenceId,
                    EvidenceLink = d.EvidenceLink,
                    TeacherForumId = d.TeacherForumId,

                }));
            }
            else
            {
                return Ok("No hay evidencia(as) para el TeacherForum.");
            }
        }

        // PUT: api/Evidences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEvidence(int id, Evidence evidence)
        //{
        //    if (id != evidence.EvidenceId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(evidence).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EvidenceExists(id))
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

        // POST: api/Evidences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("TeacherForum/{TeacherForumId}/Evidences")]
        public async Task<ActionResult<Evidence>> PostEvidence(int TeacherForumId, [FromBody] CreateEvidenceModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TeacherForum teacherForum = await _context.TeacherForums.FindAsync(TeacherForumId);

            if (teacherForum == null)
                return NotFound();

            Evidence evidence = new Evidence
            {
                EvidenceLink = model.EvidenceLink,
                TeacherForumId = TeacherForumId
            };
            _context.Evidences.Add(evidence);
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

        // DELETE: api/Evidences/5
        [HttpDelete("Evidence/{id}")]
        public async Task<IActionResult> DeleteEvidence(int id)
        {
            var existingEvidence = await _context.Evidences.FindAsync(id);
            if (existingEvidence == null)
                return NotFound();

            try
            {
                _context.Remove(existingEvidence);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingEvidence);
        }

        private bool EvidenceExists(int id)
        {
            return _context.Evidences.Any(e => e.EvidenceId == id);
        }
    }
}
