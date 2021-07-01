using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.TypeCalification;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeCalificationsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public TypeCalificationsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/TypeCalifications
        [HttpGet]
        public async Task<IEnumerable<TypeCalificationModel>> GetTypeCalifications()
        {
            var TypeCalificationList = await _context.TypeCalifications.ToListAsync();


            return TypeCalificationList.Select(d => new TypeCalificationModel
            {
                TypeCalificationId = d.TypeCalificationId,
                Name = d.Name
            });
        }

        // GET: api/TypeCalifications/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeCalificationById(int id)
        {
            var TypeCalification = await _context.TypeCalifications.FindAsync(id);

            if (TypeCalification == null)
                return NotFound();

            return Ok(new TypeCalificationModel
            {
                TypeCalificationId = TypeCalification.TypeCalificationId,
                Name = TypeCalification.Name
            });
        }

        // PUT: api/TypeCalifications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTypeCalification(int id, TypeCalification typeCalification)
        //{
        //    if (id != typeCalification.TypeCalificationId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(typeCalification).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TypeCalificationExists(id))
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

        // POST: api/TypeCalifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostTypeCalification([FromBody] CreateTypeCalificationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TypeCalification typecalification = new TypeCalification
            {
                Name = model.Name,
            };
            _context.TypeCalifications.Add(typecalification);
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

        // DELETE: api/TypeCalifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeCalification(int id)
        {
            var existingTypeCalification = await _context.TypeCalifications.FindAsync(id);
            if (existingTypeCalification == null)
                return NotFound();

            try
            {
                _context.Remove(existingTypeCalification);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingTypeCalification);
        }

        private bool TypeCalificationExists(int id)
        {
            return _context.TypeCalifications.Any(e => e.TypeCalificationId == id);
        }
    }
}
