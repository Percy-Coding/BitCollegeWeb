using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Data;
using BitCollegeWeb.Entities;
using BitCollegeWeb.Models.URL;

namespace BitCollegeWeb.Controllers
{
    [Route("api/")]
    [ApiController]
    public class URLSController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public URLSController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/URLS
        [HttpGet("URLS")]
        public async Task<IEnumerable<URLModel>> GetUrls()
        {
            var UrlList = await _context.Urls.ToListAsync();

            return UrlList.Select(d => new URLModel
            {
                UrlId = d.UrlId,
                UrlLink = d.UrlLink,
                ExternalToolId = d.ExternalToolId,
                TopicId = d.TopicId
            });
        }

        // GET: api/URLS/5
        [HttpGet("ExternalTool/{ExternalToolId}/URLS/{UrlId}")]
        public async Task<IActionResult> GetURLSByExternalToolId(int ExternalToolId, int UrlId)
        {
            ExternalTool externaltool = await _context.ExternalTools.FindAsync(ExternalToolId);
            URL url = await _context.Urls.FindAsync(UrlId);

            if (externaltool == null)
                return NotFound();

            if (url == null)
                return NotFound();

            return Ok(new URLModel
            {
                UrlId = url.UrlId,
                UrlLink = url.UrlLink,
                ExternalToolId = url.ExternalToolId
            });

        }

        // GET: api/URLS/5
        [HttpGet("Topic/{TopicId}/URLS/{UrlId}")]
        public async Task<IActionResult> GetURLSByTopicId(int TopicId, int UrlId)
        {
            Topic topic = await _context.Topics.FindAsync(TopicId);
            URL url = await _context.Urls.FindAsync(UrlId);

            if (topic == null)
                return NotFound();

            if (url == null)
                return NotFound();

            return Ok(new URLModel
            {
                UrlId = url.UrlId,
                UrlLink = url.UrlLink,
                TopicId = url.TopicId
            });
        }

        // PUT: api/URLS/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutURL(int id, URL uRL)
        //{
        //    if (id != uRL.UrlId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(uRL).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!URLExists(id))
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

        // POST: api/URLS
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("ExternalTool/{ExternalToolId}/Urls")]
        public async Task<IActionResult> PostURLByExternalToolId(int ExternalToolId, [FromBody] CreateURLModel model)
        {
            var externaltool = await _context.ExternalTools
                .Where(x => x.ExternalToolId.Equals(ExternalToolId))
                .ToListAsync();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            URL url = new URL
            {

                UrlLink = model.UrlLink

            };
            _context.Urls.Add(url);
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

        // POST: api/URLS
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Topic/{TopicId}/Urls")]
        public async Task<IActionResult> PostURLByTopicId(int TopicId, [FromBody] CreateURLModel model)
        {
            var topic = await _context.Topics
                .Where(x => x.TopicId.Equals(TopicId))
                .ToListAsync();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            URL url = new URL
            {

                UrlLink = model.UrlLink

            };
            _context.Urls.Add(url);
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

        // DELETE: api/URLS/5
        [HttpDelete("{Urlid}")]
        public async Task<IActionResult> DeleteURL(int Urlid)
        {
            var existingUrl = await _context.Urls.FindAsync(Urlid);
            if (existingUrl == null)
                return NotFound();

            try
            {
                _context.Remove(existingUrl);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingUrl);
        }

        private bool URLExists(int id)
        {
            return _context.Urls.Any(e => e.UrlId == id);
        }
    }
}
