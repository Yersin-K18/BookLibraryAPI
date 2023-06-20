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
    public class SupportOnlinesController : ControllerBase
    {
        private readonly YersinDbContext _context;

        public SupportOnlinesController(YersinDbContext context)
        {
            _context = context;
        }

        // GET: api/SupportOnlines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportOnline>>> GetSupportOnlines()
        {
          if (_context.SupportOnlines == null)
          {
              return NotFound();
          }
            return await _context.SupportOnlines.ToListAsync();
        }

        // GET: api/SupportOnlines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupportOnline>> GetSupportOnline(int id)
        {
          if (_context.SupportOnlines == null)
          {
              return NotFound();
          }
            var supportOnline = await _context.SupportOnlines.FindAsync(id);

            if (supportOnline == null)
            {
                return NotFound();
            }

            return supportOnline;
        }

        // PUT: api/SupportOnlines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupportOnline(int id, SupportOnline supportOnline)
        {
            if (id != supportOnline.Id)
            {
                return BadRequest();
            }

            _context.Entry(supportOnline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportOnlineExists(id))
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

        // POST: api/SupportOnlines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SupportOnline>> PostSupportOnline(SupportOnline supportOnline)
        {
          if (_context.SupportOnlines == null)
          {
              return Problem("Entity set 'YersinDbContext.SupportOnlines'  is null.");
          }
            _context.SupportOnlines.Add(supportOnline);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SupportOnlineExists(supportOnline.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSupportOnline", new { id = supportOnline.Id }, supportOnline);
        }

        // DELETE: api/SupportOnlines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupportOnline(int id)
        {
            if (_context.SupportOnlines == null)
            {
                return NotFound();
            }
            var supportOnline = await _context.SupportOnlines.FindAsync(id);
            if (supportOnline == null)
            {
                return NotFound();
            }

            _context.SupportOnlines.Remove(supportOnline);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupportOnlineExists(int id)
        {
            return (_context.SupportOnlines?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
