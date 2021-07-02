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
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public ChatsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/Chats
        [HttpGet]
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
        [HttpGet("{id}")]
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
        [HttpPost]
        public async Task<ActionResult> PostChat([FromBody] CreateChatModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Chat chat = new Chat
            {
                Content = model.Content,
                ClassroomId = model.ClassroomId,
                TeacherId = model.TeacherId
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
        [HttpDelete("{id}")]
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
