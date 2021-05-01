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
    public class FollowingsController : ControllerBase
    {
        private readonly PaletteContext _context;

        public FollowingsController(PaletteContext context)
        {
            _context = context;
        }

        // GET: api/Followings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Followings>>> GetFollowings()
        {
            return await _context.Followings.ToListAsync();
        }

        // GET: api/Followings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Followings>> GetFollowings(int id)
        {
            var followings = await _context.Followings.FindAsync(id);

            if (followings == null)
            {
                return NotFound();
            }

            return followings;
        }

        // PUT: api/Followings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFollowings(int id, Followings followings)
        {
            if (id != followings.FollowingsId)
            {
                return BadRequest();
            }

            _context.Entry(followings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowingsExists(id))
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

        // POST: api/Followings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Followings>> PostFollowings(Followings followings)
        {
            _context.Followings.Add(followings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFollowings", new { id = followings.FollowingsId }, followings);
        }

        // DELETE: api/Followings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Followings>> DeleteFollowings(int id)
        {
            var followings = await _context.Followings.FindAsync(id);
            if (followings == null)
            {
                return NotFound();
            }

            _context.Followings.Remove(followings);
            await _context.SaveChangesAsync();

            return followings;
        }

        private bool FollowingsExists(int id)
        {
            return _context.Followings.Any(e => e.FollowingsId == id);
        }
    }
}
