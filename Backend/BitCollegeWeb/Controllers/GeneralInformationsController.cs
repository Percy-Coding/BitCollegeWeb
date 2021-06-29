using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.Topic;

namespace BitCollegeWeb.Controllers
{
    [Route("api/ProgrammingStudy")]
    [ApiController]
    public class GeneralInformationsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public GeneralInformationsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/GeneralInformations/5
        [HttpGet("{ProgrammingStudyId}/Topics")]
        public async Task<IEnumerable<TopicModel>> GetTopicsbyProgrammingStudyId(int ProgrammingStudyId)
        {
            var generalinformation = await _context.GeneralInformations
               .Include(gi => gi.ProgrammingStudy)
               .Include(gi => gi.Topic)
               .Where(x => x.ProgrammingStudyId.Equals(ProgrammingStudyId))
               .ToListAsync();

            if (generalinformation == null)
                return null;

            return generalinformation.Select(x => new TopicModel
            {
                TopicId = x.TopicId,
                Name = x.Topic.Name,
                Description = x.Topic.Description
            });
        }

        [HttpPatch("{ProgrammingStudyId}/Topics/{TopicId}")]
        public async Task<IActionResult> AssignTopic(int ProgrammingStudyId, int TopicId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ProgrammingStudy programmingstudy = await _context.ProgrammingStudies.FindAsync(ProgrammingStudyId);
            Topic topic = await _context.Topics.FindAsync(TopicId);

            if (programmingstudy == null)
                return NotFound();

            if (topic == null)
                return NotFound();

            GeneralInformation newAssign = new GeneralInformation
            {
                ProgrammingStudyId = ProgrammingStudyId,
                TopicId = TopicId,
            };

            await _context.GeneralInformations.AddAsync(newAssign);
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

        // DELETE: api/GeneralInformations/5
        [HttpDelete("{ProgrammingStudyId}/Topics/{TopicId}")]
        public async Task<IActionResult> UnAssignTopic(int ProgrammingStudyId, int TopicId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            GeneralInformation generalinformation = await _context.GeneralInformations
                .Where(x => x.ProgrammingStudyId.Equals(ProgrammingStudyId))
                .Where(y => y.TopicId.Equals(TopicId))
                .FirstOrDefaultAsync();

            if (generalinformation == null)
                return NotFound();

            try
            {
                _context.Remove(generalinformation);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        private bool GeneralInformationExists(int id)
        {
            return _context.GeneralInformations.Any(e => e.TopicId == id);
        }
    }
}
