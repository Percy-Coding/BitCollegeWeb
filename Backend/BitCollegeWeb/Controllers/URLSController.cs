using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Domain;
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
        [HttpGet("ExternalTool/{ExternalToolId}/URLS")]
        public async Task<ActionResult<URL>> GetURLSByExternalToolId(int ExternalToolId)
        {
            IEnumerable<URL> urlList = await _context.Urls.ToListAsync();

            var UrlsListByExternalToolId = urlList.ToList().Where(d => d.ExternalToolId == ExternalToolId);

            if (UrlsListByExternalToolId.Count() > 0)
            {
                return Ok(UrlsListByExternalToolId.Select(d => new URLModel
                {
                    UrlId = d.UrlId,
                    UrlLink = d.UrlLink,
                    ExternalToolId = d.ExternalToolId,

                }));
            }
            else
            {
                return Ok("No hay url(s) para el ExternalTool.");
            }

        }

        // GET: api/URLS/5
        [HttpGet("Topic/{TopicId}/URLS")]
        public async Task<ActionResult<URL>> GetURLSByTopicId(int TopicId)
        {
            IEnumerable<URL> urlList = await _context.Urls.ToListAsync();

            var UrlsListByTopicId = urlList.ToList().Where(d => d.TopicId == TopicId);

            if (UrlsListByTopicId.Count() > 0)
            {
                return Ok(UrlsListByTopicId.Select(d => new URLModel
                {
                    UrlId = d.UrlId,
                    UrlLink = d.UrlLink,
                    TopicId = d.TopicId,

                }));
            }
            else
            {
                return Ok("No hay url(s) para el Topic.");
            }
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
        [HttpPost("ExternalTool/{ExternalToolId}/URLS")]
        public async Task<ActionResult<URL>> PostURLByExternalToolId(int ExternalToolId, [FromBody] CreateURLModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ExternalTool externaltool = await _context.ExternalTools.FindAsync(ExternalToolId);

            if (externaltool == null)
                return NotFound();

            URL url = new URL
            {
                UrlLink = model.UrlLink,
                ExternalToolId = ExternalToolId
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
        [HttpPost("Topic/{TopicId}/URLS")]
        public async Task<ActionResult<URL>> PostURLByTopicId(int TopicId, [FromBody] CreateURLModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Topic topic = await _context.Topics.FindAsync(TopicId);

            if (topic == null)
                return NotFound();

            URL url = new URL
            {
                UrlLink = model.UrlLink,
                TopicId = TopicId
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
