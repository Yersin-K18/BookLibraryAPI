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
    public class SlidesController : ControllerBase
    {
        private readonly YersinDbContext _context;

        public SlidesController(YersinDbContext context)
        {
            _context = context;
        }

        // GET: api/Slides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Slide>>> GetSlides()
        {
          if (_context.Slides == null)
          {
              return NotFound();
          }
            return await _context.Slides.ToListAsync();
        }

        // GET: api/Slides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Slide>> GetSlide(int id)
        {
          if (_context.Slides == null)
          {
              return NotFound();
          }
            var slide = await _context.Slides.FindAsync(id);

            if (slide == null)
            {
                return NotFound();
            }

            return slide;
        }

        // PUT: api/Slides/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSlide(int id, Slide slide)
        {
            if (id != slide.Id)
            {
                return BadRequest();
            }

            _context.Entry(slide).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SlideExists(id))
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

        // POST: api/Slides
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Slide>> PostSlide(Slide slide)
        {
          if (_context.Slides == null)
          {
              return Problem("Entity set 'YersinDbContext.Slides'  is null.");
          }
            _context.Slides.Add(slide);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SlideExists(slide.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSlide", new { id = slide.Id }, slide);
        }

        // DELETE: api/Slides/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlide(int id)
        {
            if (_context.Slides == null)
            {
                return NotFound();
            }
            var slide = await _context.Slides.FindAsync(id);
            if (slide == null)
            {
                return NotFound();
            }

            _context.Slides.Remove(slide);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SlideExists(int id)
        {
            return (_context.Slides?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
