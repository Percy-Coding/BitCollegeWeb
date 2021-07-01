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
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public DaysController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/Days
        [HttpGet]
        public async Task<IEnumerable<DayModel>> GetDays()
        {
            var DayList = await _context.Days.ToListAsync();


            return DayList.Select(d => new DayModel
            {
                DayId = d.DayId,
                Name = d.Name


            });
        }

        // GET: api/Days/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDayById(int id)
        {
            var Day = await _context.Days.FindAsync(id);

            if (Day == null)
                return NotFound();

            return Ok(new DayModel
            {
                DayId = Day.DayId,
                Name = Day.Name

            });
        }

        // PUT: api/Days/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDay(int id, Day day)
        //{
        //    if (id != day.DayId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(day).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DayExists(id))
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

        // POST: api/Days
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostDay([FromBody] CreateDayModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Day day = new Day
            {
                Name = model.Name

            };
            _context.Days.Add(day);
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

        // DELETE: api/Days/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDay(int id)
        {
            var existingDay = await _context.Days.FindAsync(id);
            if (existingDay == null)
                return NotFound();

            try
            {
                _context.Remove(existingDay);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingDay);
        }

        private bool DayExists(int id)
        {
            return _context.Days.Any(e => e.DayId == id);
        }
    }
}
