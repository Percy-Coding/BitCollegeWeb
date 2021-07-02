using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.Inscription;

namespace BitCollegeWeb.Controllers
{
    [Route("api")]
    [ApiController]
    public class InscriptionsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public InscriptionsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/Inscriptions
        [HttpGet("Inscriptions")]
        public async Task<IEnumerable<InscriptionModel>> GetInscriptions()
        {
            var InscriptionList = await _context.Inscriptions.ToListAsync();


            return InscriptionList.Select(d => new InscriptionModel
            {
                InscriptionId = d.InscriptionId,
                ProgrammingStudyId = d.ProgrammingStudyId,
                StudentId = d.StudentId,
                DateInscription = d.DateInscription
            });
        }

        // GET: api/Inscriptions/5
        [HttpGet("Inscription/{id}")]
        public async Task<IActionResult> GetInscriptionById(int id)
        {
            var Inscription = await _context.Inscriptions.FindAsync(id);

            if (Inscription == null)
                return NotFound();

            return Ok(new InscriptionModel
            {
                InscriptionId = Inscription.InscriptionId,
                ProgrammingStudyId = Inscription.ProgrammingStudyId,
                StudentId = Inscription.StudentId,
                DateInscription = Inscription.DateInscription

            });
        }


        [HttpGet("ProgrammingStudy/{ProgrammingStudyId}/Inscriptions")]
        public async Task<ActionResult<Inscription>> GetInscriptionsByProgrammingStudyId(int ProgrammingStudyId)
        {
            IEnumerable<Inscription> InscriptionList = await _context.Inscriptions.ToListAsync();

            var InscriptionsListByProgrammingStudyId = InscriptionList.ToList().Where(d => d.ProgrammingStudyId == ProgrammingStudyId);

            if (InscriptionsListByProgrammingStudyId.Count() > 0)
            {
                return Ok(InscriptionsListByProgrammingStudyId.Select(d => new InscriptionModel
                {
                    InscriptionId = d.InscriptionId,
                    ProgrammingStudyId = d.ProgrammingStudyId,
                    StudentId = d.StudentId,
                    DateInscription = d.DateInscription

                }));
            }
            else
            {
                return Ok("No hay inscripcion(es) para el ProgrammingStudy.");
            }
        }

        // PUT: api/Inscriptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutInscription(int id, Inscription inscription)
        //{
        //    if (id != inscription.InscriptionId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(inscription).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!InscriptionExists(id))
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

        // POST: api/Inscriptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Inscriptions")]
        public async Task<IActionResult> PostInscription([FromBody] CreateInscriptionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Inscription inscription = new Inscription
            {
                ProgrammingStudyId = model.ProgrammingStudyId,
                StudentId = model.StudentId,
                DateInscription = model.DateInscription

            };
            _context.Inscriptions.Add(inscription);
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

        // DELETE: api/Inscriptions/5
        [HttpDelete("Inscription/{id}")]
        public async Task<IActionResult> DeleteInscription(int id)
        {
            var existingInscription = await _context.Inscriptions.FindAsync(id);
            if (existingInscription == null)
                return NotFound();

            try
            {
                _context.Remove(existingInscription);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingInscription);
        }

        private bool InscriptionExists(int id)
        {
            return _context.Inscriptions.Any(e => e.InscriptionId == id);
        }
    }
}
