using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.Day;

namespace BitCollegeWeb.Controllers
{
    [Route("api")]
    [ApiController]
    public class ScheduleDaysController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public ScheduleDaysController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/ScheduleDays
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ScheduleDay>>> GetScheduleDays()
        //{
        //    return await _context.ScheduleDays.ToListAsync();
        //}

        // GET: api/ScheduleDays/5
        [HttpGet("Schedule/{ScheduleId}/Days")]
        public async Task<IEnumerable<DayModel>> GetDaysByScheduleId(int ScheduleId)
        {
            var scheduledays = await _context.ScheduleDays
               .Include(st => st.Schedule)
               .Include(st => st.Day)
               .Where(x => x.ScheduleId.Equals(ScheduleId))
               .ToListAsync();

            if (scheduledays == null)
                return null;

            return scheduledays.Select(x => new DayModel
            {
                DayId = x.DayId,
                Name = x.Day.Name
            });
        } 

        [HttpPatch("Schedule/{ScheduleId}/Day/{DayId}")]
        public async Task<IActionResult> AssignDay(int ScheduleId, int DayId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Schedule schedule = await _context.Schedules.FindAsync(ScheduleId);
            Day day = await _context.Days.FindAsync(DayId);

            if (schedule == null)
                return NotFound();

            if (day == null)
                return NotFound();

            ScheduleDay newAssign = new ScheduleDay
            {
                ScheduleId = ScheduleId,
                DayId = DayId,
            };

            await _context.ScheduleDays.AddAsync(newAssign);
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

        // DELETE: api/ScheduleDays/5
        [HttpDelete("Schedule/{ScheduleId}/Day/{DayId}")]
        public async Task<IActionResult> UnAssignDay(int ScheduleId, int DayId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ScheduleDay scheduleday = await _context.ScheduleDays
                .Where(x => x.ScheduleId.Equals(ScheduleId))
                .Where(y => y.DayId.Equals(DayId))
                .FirstOrDefaultAsync();

            if (scheduleday == null)
                return NotFound();

            try
            {
                _context.Remove(scheduleday);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        private bool ScheduleDayExists(int id)
        {
            return _context.ScheduleDays.Any(e => e.ScheduleId == id);
        }
    }
}
