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
    public class ApikeysController : ControllerBase
    {
        private readonly PaletteContext _context;

        public ApikeysController(PaletteContext context)
        {
            _context = context;
        }

        // GET: api/Apikeys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apikeys>>> GetApikeys()
        {
            return await _context.Apikeys.ToListAsync();
        }

        // GET: api/Apikeys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Apikeys>> GetApikeys(int id)
        {
            var apikeys = await _context.Apikeys.FindAsync(id);

            if (apikeys == null)
            {
                return NotFound();
            }

            return apikeys;
        }

        // PUT: api/Apikeys/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApikeys(int id, Apikeys apikeys)
        {
            if (id != apikeys.ApikeyId)
            {
                return BadRequest();
            }

            _context.Entry(apikeys).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApikeysExists(id))
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

        // POST: api/Apikeys
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Apikeys>> PostApikeys(Apikeys apikeys)
        {
            _context.Apikeys.Add(apikeys);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApikeys", new { id = apikeys.ApikeyId }, apikeys);
        }

        // DELETE: api/Apikeys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Apikeys>> DeleteApikeys(int id)
        {
            var apikeys = await _context.Apikeys.FindAsync(id);
            if (apikeys == null)
            {
                return NotFound();
            }

            _context.Apikeys.Remove(apikeys);
            await _context.SaveChangesAsync();

            return apikeys;
        }

        private bool ApikeysExists(int id)
        {
            return _context.Apikeys.Any(e => e.ApikeyId == id);
        }
    }
}
