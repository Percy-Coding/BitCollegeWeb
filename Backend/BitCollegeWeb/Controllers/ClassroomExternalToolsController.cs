using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.ExternalTool;

namespace BitCollegeWeb.Controllers
{
    [Route("api/Classroom")]
    [ApiController]
    public class ClassroomExternalToolsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public ClassroomExternalToolsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/ClassroomExternalTools
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ClassroomExternalTool>>> GetClassroomExternalTools()
        //{
        //    return await _context.ClassroomExternalTools.ToListAsync();
        //}

        // GET: api/ClassroomExternalTools/5
        [HttpGet("{ClassroomId}/ExternalTools")]
        public async Task<IEnumerable<ExternalToolModel>> GetExternalToolsByClassroomId(int ClassroomId)
        {
            var classroomexternaltools = await _context.ClassroomExternalTools
               .Include(st => st.Classroom)
               .Include(st => st.ExternalTool)
               .Where(x => x.ClassroomId.Equals(ClassroomId))
               .ToListAsync();

            if (classroomexternaltools == null)
                return null;

            return classroomexternaltools.Select(x => new ExternalToolModel
            {
                ExternalToolId = x.ExternalToolId,
                Name = x.ExternalTool.Name,
                Description = x.ExternalTool.Description

            });
        }

        [HttpPatch("{ClassroomId}/Externaltools/{ExternalToolId}")]
        public async Task<IActionResult> AssignExternalTool(int ClassroomId, int ExternalToolId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Classroom classroom = await _context.Classrooms.FindAsync(ClassroomId);
            ExternalTool externaltool = await _context.ExternalTools.FindAsync(ExternalToolId);

            if (classroom == null)
                return NotFound();

            if (externaltool == null)
                return NotFound();

            ClassroomExternalTool newAssign = new ClassroomExternalTool
            {
                ClassroomId = ClassroomId,
                ExternalToolId = ExternalToolId,
            };

            await _context.ClassroomExternalTools.AddAsync(newAssign);
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

        // DELETE: api/ClassroomExternalTools/5
        [HttpDelete("{ClassroomId}/ExternalTools/{ExternalToolId}")]
        public async Task<IActionResult> UnAssignExternalTool(int ClassroomId, int ExternalToolId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ClassroomExternalTool classroomexternaltool = await _context.ClassroomExternalTools
                .Where(x => x.ClassroomId.Equals(ClassroomId))
                .Where(y => y.ExternalToolId.Equals(ExternalToolId))
                .FirstOrDefaultAsync();

            if (classroomexternaltool == null)
                return NotFound();

            try
            {
                _context.Remove(classroomexternaltool);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        private bool ClassroomExternalToolExists(int id)
        {
            return _context.ClassroomExternalTools.Any(e => e.ExternalToolId == id);
        }
    }
}
