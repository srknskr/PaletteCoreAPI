using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaletteCoreAPI.Models;

namespace PaletteCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostColorsController : ControllerBase
    {
        private readonly PaletteContext _context;

        public PostColorsController(PaletteContext context)
        {
            _context = context;
        }

        // GET: api/PostColors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostColors>>> GetPostColors()
        {
            return await _context.PostColors.ToListAsync();
        }

        // GET: api/PostColors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostColors>> GetPostColors(int id)
        {
            var postColors = await _context.PostColors.FindAsync(id);

            if (postColors == null)
            {
                return NotFound();
            }

            return postColors;
        }

        // PUT: api/PostColors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostColors(int id, PostColors postColors)
        {
            if (id != postColors.PostColorId)
            {
                return BadRequest();
            }

            _context.Entry(postColors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostColorsExists(id))
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

        // POST: api/PostColors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PostColors>> PostPostColors(PostColors postColors)
        {
            _context.PostColors.Add(postColors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostColors", new { id = postColors.PostColorId }, postColors);
        }

        // DELETE: api/PostColors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PostColors>> DeletePostColors(int id)
        {
            var postColors = await _context.PostColors.FindAsync(id);
            if (postColors == null)
            {
                return NotFound();
            }

            _context.PostColors.Remove(postColors);
            await _context.SaveChangesAsync();

            return postColors;
        }

        private bool PostColorsExists(int id)
        {
            return _context.PostColors.Any(e => e.PostColorId == id);
        }
    }
}
