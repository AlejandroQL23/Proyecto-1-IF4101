using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIProject.Models.Entities;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsCommentsController : ControllerBase
    {
        private readonly ALDIFA_SOFT_API_IF4101Context _context;

        public NewsCommentsController(ALDIFA_SOFT_API_IF4101Context context)
        {
            _context = context;
        }

        // GET: api/NewsComments
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsComment>>> GetNewsComments()
        {
            return await _context.NewsComment.ToListAsync();
        }

        // GET: api/NewsComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsComment>> GetNewsComment(int id)
        {
            var newsComment = await _context.NewsComment.FindAsync(id);

            if (newsComment == null)
            {
                return NotFound();
            }

            return newsComment;
        }

        // PUT: api/NewsComments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewsComment(int id, NewsComment newsComment)
        {
            if (id != newsComment.Id)
            {
                return BadRequest();
            }

            _context.Entry(newsComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsCommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NewsComments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NewsComment>> PostNewsComment(NewsComment newsComment)
        {
            _context.NewsComment.Add(newsComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewsComment", new { id = newsComment.Id }, newsComment);
        }

        // DELETE: api/NewsComments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NewsComment>> DeleteNewsComment(int id)
        {
            var newsComment = await _context.NewsComment.FindAsync(id);
            if (newsComment == null)
            {
                return NotFound();
            }

            _context.NewsComment.Remove(newsComment);
            await _context.SaveChangesAsync();

            return newsComment;
        }

        private bool NewsCommentExists(int id)
        {
            return _context.NewsComment.Any(e => e.Id == id);
        }
    }
}
