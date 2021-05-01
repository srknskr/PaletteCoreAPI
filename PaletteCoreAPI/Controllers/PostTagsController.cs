﻿using System;
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
    public class PostTagsController : ControllerBase
    {
        private readonly PaletteContext _context;

        public PostTagsController(PaletteContext context)
        {
            _context = context;
        }

        // GET: api/PostTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostTags>>> GetPostTags()
        {
            return await _context.PostTags.ToListAsync();
        }

        // GET: api/PostTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostTags>> GetPostTags(int id)
        {
            var postTags = await _context.PostTags.FindAsync(id);

            if (postTags == null)
            {
                return NotFound();
            }

            return postTags;
        }

        // PUT: api/PostTags/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostTags(int id, PostTags postTags)
        {
            if (id != postTags.PostTagId)
            {
                return BadRequest();
            }

            _context.Entry(postTags).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostTagsExists(id))
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

        // POST: api/PostTags
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PostTags>> PostPostTags(PostTags postTags)
        {
            _context.PostTags.Add(postTags);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostTags", new { id = postTags.PostTagId }, postTags);
        }

        // DELETE: api/PostTags/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PostTags>> DeletePostTags(int id)
        {
            var postTags = await _context.PostTags.FindAsync(id);
            if (postTags == null)
            {
                return NotFound();
            }

            _context.PostTags.Remove(postTags);
            await _context.SaveChangesAsync();

            return postTags;
        }

        private bool PostTagsExists(int id)
        {
            return _context.PostTags.Any(e => e.PostTagId == id);
        }
    }
}
