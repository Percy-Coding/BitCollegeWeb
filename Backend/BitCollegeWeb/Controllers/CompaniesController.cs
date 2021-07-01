using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.Company;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public CompaniesController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<IEnumerable<CompanyModel>> GetCompanies()
        {
            var CompanyList = await _context.Companies.ToListAsync();


            return CompanyList.Select(d => new CompanyModel
            {
                CompanyId = d.CompanyId,
                Name = d.Name,
                Description = d.Description

            });
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var Company = await _context.Companies.FindAsync(id);

            if (Company == null)
                return NotFound();

            return Ok(new CompanyModel
            {
                CompanyId = Company.CompanyId,
                Name = Company.Name,
                Description = Company.Description,
            });
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCompany(int id, Company company)
        //{
        //    if (id != company.CompanyId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(company).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CompanyExists(id))
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

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostCompany([FromBody] CreateCompanyModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Company company = new Company
            {
                Name = model.Name,
                Description = model.Description,
            };
            _context.Companies.Add(company);
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

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var existingCompany = await _context.Companies.FindAsync(id);
            if (existingCompany == null)
                return NotFound();

            try
            {
                _context.Remove(existingCompany);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingCompany);
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.CompanyId == id);
        }
    }
}
