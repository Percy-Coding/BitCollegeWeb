using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.Schedule;

namespace BitCollegeWeb.Controllers
{
    [Route("api")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public SchedulesController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/Schedules
        [HttpGet("Schedules")]
        public async Task<IEnumerable<ScheduleModel>> GetSchedules()
        {
            var ScheduleList = await _context.Schedules.ToListAsync();


            return ScheduleList.Select(d => new ScheduleModel
            {
                ScheduleId = d.ScheduleId,
                TypeProgrammingClassId = d.TypeProgrammingClassId,
                StudentId = d.StudentId

            });
        }

        // GET: api/Schedules/5
        [HttpGet("Schedule/{id}")]
        public async Task<IActionResult> GetScheduleById(int id)
        {
            var Schedule = await _context.Schedules.FindAsync(id);

            if (Schedule == null)
                return NotFound();

            return Ok(new ScheduleModel
            {
                ScheduleId = Schedule.ScheduleId,
                TypeProgrammingClassId = Schedule.TypeProgrammingClassId,
                StudentId = Schedule.StudentId

            });
        }

        [HttpGet("Student/{StudentId}/Schedules")]
        public async Task<ActionResult<Schedule>> GetSchedulesByStudentId(int StudentId)
        {
            IEnumerable<Schedule> ScheduleList = await _context.Schedules.ToListAsync();

            var SchedulesListByStudentId = ScheduleList.ToList().Where(d => d.StudentId == StudentId);

            if (SchedulesListByStudentId.Count() > 0)
            {
                return Ok(SchedulesListByStudentId.Select(d => new ScheduleModel
                {
                    ScheduleId = d.ScheduleId,
                    TypeProgrammingClassId = d.TypeProgrammingClassId,
                    StudentId = d.StudentId

                }));
            }
            else
            {
                return Ok("No hay schedule(s) para el student.");
            }
        }

        // PUT: api/Schedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSchedule(int id, Schedule schedule)
        //{
        //    if (id != schedule.ScheduleId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(schedule).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ScheduleExists(id))
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

        // POST: api/Schedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Schedules")]
        public async Task<IActionResult> PostSchedule([FromBody] CreateScheduleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Schedule schedule = new Schedule
            {
                TypeProgrammingClassId = model.TypeProgrammingClassId,
                StudentId = model.StudentId

            };
            _context.Schedules.Add(schedule);
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

        // DELETE: api/Schedules/5
        [HttpDelete("Schedule/{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var existingSchedule = await _context.Schedules.FindAsync(id);
            if (existingSchedule == null)
                return NotFound();

            try
            {
                _context.Remove(existingSchedule);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingSchedule);
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedules.Any(e => e.ScheduleId == id);
        }
    }
}
