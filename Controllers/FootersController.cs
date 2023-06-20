using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookLibraryAPI.Data;
using BookLibraryAPI.Models;

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootersController : ControllerBase
    {
        private readonly YersinDbContext _context;

        public FootersController(YersinDbContext context)
        {
            _context = context;
        }

        // GET: api/Footers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Footer>>> GetFooters()
        {
          if (_context.Footers == null)
          {
              return NotFound();
          }
            return await _context.Footers.ToListAsync();
        }

        // GET: api/Footers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Footer>> GetFooter(int id)
        {
          if (_context.Footers == null)
          {
              return NotFound();
          }
            var footer = await _context.Footers.FindAsync(id);

            if (footer == null)
            {
                return NotFound();
            }

            return footer;
        }

        // PUT: api/Footers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFooter(int id, Footer footer)
        {
            if (id != footer.Id)
            {
                return BadRequest();
            }

            _context.Entry(footer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FooterExists(id))
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

        // POST: api/Footers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Footer>> PostFooter(Footer footer)
        {
          if (_context.Footers == null)
          {
              return Problem("Entity set 'YersinDbContext.Footers'  is null.");
          }
            _context.Footers.Add(footer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FooterExists(footer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFooter", new { id = footer.Id }, footer);
        }

        // DELETE: api/Footers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFooter(int id)
        {
            if (_context.Footers == null)
            {
                return NotFound();
            }
            var footer = await _context.Footers.FindAsync(id);
            if (footer == null)
            {
                return NotFound();
            }

            _context.Footers.Remove(footer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FooterExists(int id)
        {
            return (_context.Footers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
