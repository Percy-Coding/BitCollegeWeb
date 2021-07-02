using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Models.Announcement;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public AnnouncementsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/Announcements
        [HttpGet]
        public async Task<IEnumerable<AnnouncementModel>> GetAnnouncements()
        {
            var announcementList = await _context.Announcements.ToListAsync();

            return announcementList.Select(a => new AnnouncementModel
            {
                AnnouncementId = a.AnnouncementId,
                Title = a.Title,
                DateLimit = a.DateLimit,
                Description = a.Description,
                SectionId = a.SectionId
            });
        }

        [HttpGet("Section/{SectionId}/Announcements")]
        public async Task<ActionResult<AnnouncementModel>> GetAnnouncementsBySectionId(int SectionId)
        {
            IEnumerable<Announcement> announcementList = await _context.Announcements.ToListAsync();
            var announcementListBySectionId = announcementList.ToList().Where(a => a.SectionId == SectionId);


            if(announcementListBySectionId.Count() > 0)
            {
                return Ok(announcementListBySectionId.Select(a => new AnnouncementModel
                {
                    AnnouncementId = a.AnnouncementId,
                    Title = a.Title,
                    DateLimit = a.DateLimit,
                    Description = a.Description,
                    SectionId = a.SectionId
                }));
            }
            else
            {
                return Ok("No existen anuncios para esta Sección");
            }
        }

        // GET: api/Announcements/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAnnouncementById(int id)
        {
            var announcement = await _context.Announcements.FindAsync(id);

            if (announcement == null)
            {
                return NotFound();
            }

            return Ok(new AnnouncementModel
            {
                AnnouncementId = announcement.AnnouncementId,
                Title = announcement.Title,
                DateLimit = announcement.DateLimit,
                Description = announcement.Description,
                SectionId = announcement.SectionId
            });
        }


        // POST: api/Announcements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Section/{SectionId}/Announcement")]
        public async Task<ActionResult> PostAnnouncement(int SectionId, [FromBody] CreateAnnouncementModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Section section = await _context.Sections.FindAsync(SectionId);

            if (section == null)
                return NotFound();

            Announcement announcement = new Announcement
            {
                Title = model.Title,
                DateLimit = model.DateLimit,
                Description = model.Description,
                SectionId = SectionId
            };

            _context.Announcements.Add(announcement);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(model);

        }

        // DELETE: api/Announcements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnouncement(int id)
        {
            var announcement = await _context.Announcements.FindAsync(id);
            if (announcement == null)
            {
                return NotFound();
            }
            try
            {
                _context.Announcements.Remove(announcement);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(announcement);
        }
    }
}
