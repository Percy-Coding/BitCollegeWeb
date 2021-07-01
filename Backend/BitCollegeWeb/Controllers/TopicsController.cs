using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitCollegeWeb.Infrastructure;
using BitCollegeWeb.Domain;
using BitCollegeWeb.Models.Topic;

namespace BitCollegeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly DbContextBitCollegeWeb _context;

        public TopicsController(DbContextBitCollegeWeb context)
        {
            _context = context;
        }

        // GET: api/Topics
        [HttpGet]
        public async Task<IEnumerable<TopicModel>> GetTopics()
        {
            var topicList = await _context.Topics.ToListAsync();

            return topicList.Select(d => new TopicModel
            {
                TopicId = d.TopicId,
                Name = d.Name,
                Description = d.Description
            });
        }

        // GET: api/Topics/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopicById(int id)
        {
            var topic = await _context.Topics.FindAsync(id);

            if (topic == null)
                return NotFound();

            return Ok(new TopicModel
            {
                TopicId = topic.TopicId,
                Name = topic.Name,
                Description = topic.Description

            });
        }

        // PUT: api/Topics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopic(int id, [FromBody] UpdateTopicModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id <= 0)
                return BadRequest();

            var topic = await _context.Topics.FirstOrDefaultAsync(d => d.TopicId == id);

            if (topic == null)
                return NotFound();

            topic.Name = model.Name;
            topic.Description = model.Description;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(model);
        }

        // POST: api/Topics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostTopic([FromBody] CreateTopicModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Topic topic = new Topic
            {
                Name = model.Name,
                Description = model.Description
            };
            _context.Topics.Add(topic);
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

        // DELETE: api/Topics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var existingTopic = await _context.Topics.FindAsync(id);
            if (existingTopic == null)
                return NotFound();

            try
            {
                _context.Remove(existingTopic);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(existingTopic);
        }

        private bool TopicExists(int id)
        {
            return _context.Topics.Any(e => e.TopicId == id);
        }
    }
}
