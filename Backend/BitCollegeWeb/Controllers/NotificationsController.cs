using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.Notification;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public NotificationsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/Notifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notification>>> GetNotifications()
        {
            return await _context.Notifications.ToListAsync();
        }

        // GET: api/Notifications/5
        [HttpGet("Student/{StudentId}/Notifications")]
        public async Task<ActionResult<Notification>> GetNotificationByStudentId(int StudentId)
        {
            IEnumerable<Notification> notificationList = await _context.Notifications.ToListAsync();

            var notificationListByStudentId = notificationList.ToList().Where(d => d.StudentId == StudentId);

            if (notificationListByStudentId.Count() > 0)
            {
                return Ok(notificationListByStudentId.Select(d => new NotificationModel
                {
                   NotificationId = d.NotificationId,
                   Title = d.Title,
                   Description= d.Description,
                   Date = d.Date, 
                   StudentId = (int)d.StudentId,
                   TeacherId = (int)d.TeacherId

                }));
            }
            else
            {
                return Ok("No hay notificacions para este Student.");
            }
        }

        // GET: api/Notifications/5
        [HttpGet("Teacher/{TeacherId}/Notifications")]
        public async Task<ActionResult<Notification>> GetNotificationByTeacherId(int TeacherId)
        {
            IEnumerable<Notification> notificationList = await _context.Notifications.ToListAsync();

            var notificationListByTeacherId = notificationList.ToList().Where(d => d.TeacherId == TeacherId);

            if (notificationListByTeacherId.Count() > 0)
            {
                return Ok(notificationListByTeacherId.Select(d => new NotificationModel
                {
                    NotificationId = d.NotificationId,
                    Title = d.Title,
                    Description = d.Description,
                    Date = d.Date,
                    StudentId = (int)d.StudentId,
                    TeacherId = (int)d.TeacherId

                }));
            }
            else
            {
                return Ok("No hay notificacions para este Teacher.");
            }
        }


        // POST: api/Notifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Teacher/{TeacherId}/Notification")]
        public async Task<ActionResult<Assignment>> PostNotification(int TeacherId, [FromBody] CreateNotificationModel model)
        { 
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Teacher teacher = await _context.Teachers.FindAsync(TeacherId);

            if (teacher == null)
                return NotFound();

            Notification notification = new Notification
            {
                Title = model.Title,
                Description = model.Description,
                Date = model.Date,
                StudentId = (int)model.StudentId,
                TeacherId = (int)model.TeacherId
            };
            _context.Notifications.Add(notification);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var existingNotification = await _context.Notifications.FindAsync(id);
            if (existingNotification == null)
                return NotFound();

            try
            {
                _context.Remove(existingNotification);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingNotification);
        }

        private bool NotificationExists(int id)
        {
            return _context.Notifications.Any(e => e.NotificationId == id);
        }

    }
}
