using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Models.Chat;

namespace BitCollegeWeb.Controllers
{
    [Route("api")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public ChatsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/Chats
        [HttpGet("Chats")]
        public async Task<IEnumerable<ChatModel>> GetChats()
        {
            var ChatList = await _context.Chats.ToListAsync();

            return ChatList.Select(d => new ChatModel
            {
                ChatId = d.ChatId,
                Content = d.Content,
                ClassroomId = d.ClassroomId,
                TeacherId = d.TeacherId
            });
        }

        // GET: api/Chats/5
        [HttpGet("Chat/{id}")]
        public async Task<IActionResult> GetChatById(int id)
        {
            var chat = await _context.Chats.FindAsync(id);

            if (chat == null)
            {
                return NotFound();
            }

            return Ok(new ChatModel
            {
                ChatId = chat.ChatId,
                Content = chat.Content,
                ClassroomId = chat.ClassroomId,
                TeacherId = chat.TeacherId
            });
        }

        // POST: api/Chats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Classroom/{ClassroomId}/Chats")]
        public async Task<ActionResult<Chat>> PostChatByClassroomId(int ClassroomId,[FromBody] CreateChatModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Classroom classroom = await _context.Classrooms.FindAsync(ClassroomId);

            if (classroom == null)
                return NotFound();

            Chat chat = new Chat
            {
                Content = model.Content,
                ClassroomId = ClassroomId
            };
            _context.Chats.Add(chat);
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

        [HttpPost("Teacher/{TeacherId}/Chats")]
        public async Task<ActionResult<Chat>> PostChatByTeacherId(int TeacherId, [FromBody] CreateChatModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Teacher teacher = await _context.Teachers.FindAsync(TeacherId);

            if (teacher == null)
                return NotFound();

            Chat chat = new Chat
            {
                Content = model.Content,
                TeacherId = TeacherId
            };
            _context.Chats.Add(chat);
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

        // DELETE: api/Chats/5
        [HttpDelete("Chat/{id}")]
        public async Task<IActionResult> DeleteChat(int id)
        {
            var chat = await _context.Chats.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }
            try
            {
                _context.Chats.Remove(chat);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(chat);
          
        }
    }
}
