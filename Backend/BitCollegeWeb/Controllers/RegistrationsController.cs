using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.Registration;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public RegistrationsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/Registrations
        [HttpGet]
        public async Task<IEnumerable<RegistrationModel>> GetRegistrations()
        {
            var registrationList = await _context.Registrations.ToListAsync();


            return registrationList.Select(d => new RegistrationModel
            {
                RegistrationId = d.RegistrationId,
                Date = d.Date,
                Email = d.Email,
                StudentId = d.StudentId,
                TeacherId = d.TeacherId

            });
        }

        // GET: api/Registrations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistrationById(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);

            if (registration == null)
                return NotFound();

            return Ok(new RegistrationModel
            {
                RegistrationId = registration.RegistrationId,
                Date = registration.Date,
                Email = registration.Email,
                StudentId = registration.StudentId,
                TeacherId = registration.TeacherId
            });
        }

        // PUT: api/Registrations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRegistration(int id, Registration registration)
        //{
        //    if (id != registration.RegistrationId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(registration).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RegistrationExists(id))
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

        // POST: api/Registrations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostRegistration([FromBody] CreateRegistrationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Registration registration = new Registration
            {
                Date = model.Date,
                Email = model.Email,
                Password = model.Password,
                StudentId = model.StudentId,
                TeacherId = model.TeacherId,

            };
            _context.Registrations.Add(registration);
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

        // DELETE: api/Registrations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            var existingRegistration = await _context.Registrations.FindAsync(id);
            if (existingRegistration == null)
                return NotFound();

            try
            {
                _context.Remove(existingRegistration);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingRegistration);
        }

        private bool RegistrationExists(int id)
        {
            return _context.Registrations.Any(e => e.RegistrationId == id);
        }
    }
}
