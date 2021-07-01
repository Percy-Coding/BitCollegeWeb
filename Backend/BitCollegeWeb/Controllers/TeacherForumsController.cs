using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.TeacherForum;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherForumsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public TeacherForumsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/TeacherForums
        [HttpGet]
        public async Task<IEnumerable<TeacherForumModel>> GetTeacherForums()
        {
            var TeacherForumList = await _context.TeacherForums.ToListAsync();


            return TeacherForumList.Select(d => new TeacherForumModel
            {
                TeacherForumId = d.TeacherForumId,
                ProblemDescription = d.ProblemDescription,
                Date = d.Date

            });
        }

        // GET: api/TeacherForums/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherForumById(int id)
        {
            var TeacherForum = await _context.TeacherForums.FindAsync(id);

            if (TeacherForum == null)
                return NotFound();

            return Ok(new TeacherForumModel
            {
                TeacherForumId = TeacherForum.TeacherForumId,
                ProblemDescription = TeacherForum.ProblemDescription,
                Date = TeacherForum.Date
            });
        }

        // PUT: api/TeacherForums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTeacherForum(int id, TeacherForum teacherForum)
        //{
        //    if (id != teacherForum.TeacherForumId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(teacherForum).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TeacherForumExists(id))
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

        // POST: api/TeacherForums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostTeacherForum([FromBody] CreateTeacherForumModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TeacherForum teacherForum = new TeacherForum
            {
                ProblemDescription = model.ProblemDescription,
                Date = model.Date
            };
            _context.TeacherForums.Add(teacherForum);
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

        // DELETE: api/TeacherForums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacherForum(int id)
        {
            var existingTeacherForum = await _context.TeacherForums.FindAsync(id);
            if (existingTeacherForum == null)
                return NotFound();

            try
            {
                _context.Remove(existingTeacherForum);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingTeacherForum);
        }

        private bool TeacherForumExists(int id)
        {
            return _context.TeacherForums.Any(e => e.TeacherForumId == id);
        }
    }
}
