using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.Classroom;

namespace BitCollegeWeb.Controllers
{
    [Route("api")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public ClassroomsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/Classrooms
        [HttpGet("Classrooms")]
        public async Task<IEnumerable<ClassroomModel>> GetClassrooms()
        {
            var classroomList = await _context.Classrooms.ToListAsync();


            return classroomList.Select(d => new ClassroomModel
            {
                ClassroomId = d.ClassroomId,
                DateStart = d.DateStart,
                Name = d.Name,
                SectionId = d.SectionId,
                TeacherForumId = d.TeacherForumId

            });
        }

        // GET: api/Classrooms/5
        [HttpGet("Classroom/{id}")]
        public async Task<IActionResult> GetClassroomById(int id)
        {
            var classroom = await _context.Classrooms.FindAsync(id);

            if (classroom == null)
                return NotFound();

            return Ok(new ClassroomModel
            {
                ClassroomId = classroom.ClassroomId,
                DateStart = classroom.DateStart,
                Name = classroom.Name,
                SectionId = classroom.SectionId,
                TeacherForumId = classroom.TeacherForumId
            });
        }

        [HttpGet("Section/{SectionId}/Classrooms")]
        public async Task<ActionResult<Classroom>> GetClassroomsBySectionId(int SectionId)
        {
            IEnumerable<Classroom> classroomList = await _context.Classrooms.ToListAsync();

            var ClassroomsListBySectionId = classroomList.ToList().Where(d => d.SectionId == SectionId);

            if (ClassroomsListBySectionId.Count() > 0)
            {
                return Ok(ClassroomsListBySectionId.Select(d => new ClassroomModel
                {
                    ClassroomId = d.ClassroomId,
                    DateStart = d.DateStart,
                    Name = d.Name,
                    SectionId = d.SectionId,
                    TeacherForumId = d.TeacherForumId

                }));
            }
            else
            {
                return Ok("No hay salon(es) para el Section.");
            }
        }

        // PUT: api/Classrooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Classroom/{id}")]
        public async Task<IActionResult> PutClassroom(int id, [FromBody] UpdateClassroomModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest();

            var classroom = await _context.Classrooms.FirstOrDefaultAsync(d => d.ClassroomId == id);

            if (classroom == null)
                return NotFound();



            classroom.DateStart = model.DateStart;
            classroom.Name = model.Name;

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

        // POST: api/Classrooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Classrooms")]
        public async Task<IActionResult> PostClassroom([FromBody] CreateClassroomModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Classroom classroom = new Classroom
            {
                DateStart = model.DateStart,
                Name = model.Name,
                SectionId = model.SectionId,
                TeacherForumId = model.TeacherForumId
            };
            _context.Classrooms.Add(classroom);
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

        // DELETE: api/Classrooms/5
        [HttpDelete("Classroom/{id}")]
        public async Task<IActionResult> DeleteClassroom(int id)
        {
            var existingClassroom = await _context.Classrooms.FindAsync(id);
            if (existingClassroom == null)
                return NotFound();

            try
            {
                _context.Remove(existingClassroom);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingClassroom);
        }

        private bool ClassroomExists(int id)
        {
            return _context.Classrooms.Any(e => e.ClassroomId == id);
        }
    }
}
