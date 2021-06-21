using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Data;
using BitCollegeWeb.Entities;
using BitCollegeWeb.Models.TypeProgrammingClass;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeProgrammingClassesController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public TypeProgrammingClassesController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/TypeProgrammingClasses
        [HttpGet]
        public async Task<IEnumerable<TypeProgrammingClassModel>> GetTypeProgrammingClasses()
        {
            var TypeProgrammingClassList = await _context.TypeProgrammingClasses.ToListAsync();


            return TypeProgrammingClassList.Select(d => new TypeProgrammingClassModel
            {
                TypeProgrammingClassId = d.TypeProgrammingClassId,
                Name = d.Name

            });
        }

        // GET: api/TypeProgrammingClasses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeProgrammingClassById(int id)
        {
            var TypeProgrammingClass = await _context.TypeProgrammingClasses.FindAsync(id);

            if (TypeProgrammingClass == null)
                return NotFound();

            return Ok(new TypeProgrammingClassModel
            {
                TypeProgrammingClassId = TypeProgrammingClass.TypeProgrammingClassId,
                Name = TypeProgrammingClass.Name

            });
        }

        // PUT: api/TypeProgrammingClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTypeProgrammingClass(int id, TypeProgrammingClass typeProgrammingClass)
        //{
        //    if (id != typeProgrammingClass.TypeProgrammingClassId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(typeProgrammingClass).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TypeProgrammingClassExists(id))
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

        // POST: api/TypeProgrammingClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostTypeProgrammingClass([FromBody] CreateTypeProgrammingClassModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TypeProgrammingClass Typeprogrammingclass = new TypeProgrammingClass
            {
                Name = model.Name
            };
            _context.TypeProgrammingClasses.Add(Typeprogrammingclass);
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

        // DELETE: api/TypeProgrammingClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeProgrammingClass(int id)
        {
            var existingTypeProgrammingclass = await _context.TypeProgrammingClasses.FindAsync(id);
            if (existingTypeProgrammingclass == null)
                return NotFound();

            try
            {
                _context.Remove(existingTypeProgrammingclass);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingTypeProgrammingclass);
        }

        private bool TypeProgrammingClassExists(int id)
        {
            return _context.TypeProgrammingClasses.Any(e => e.TypeProgrammingClassId == id);
        }
    }
}
