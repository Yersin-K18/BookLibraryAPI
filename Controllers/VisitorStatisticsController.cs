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
    public class VisitorStatisticsController : ControllerBase
    {
        private readonly YersinDbContext _context;

        public VisitorStatisticsController(YersinDbContext context)
        {
            _context = context;
        }

        // GET: api/VisitorStatistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitorStatistic>>> GetVisitorStatistics()
        {
          if (_context.VisitorStatistics == null)
          {
              return NotFound();
          }
            return await _context.VisitorStatistics.ToListAsync();
        }

        // GET: api/VisitorStatistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VisitorStatistic>> GetVisitorStatistic(Guid id)
        {
          if (_context.VisitorStatistics == null)
          {
              return NotFound();
          }
            var visitorStatistic = await _context.VisitorStatistics.FindAsync(id);

            if (visitorStatistic == null)
            {
                return NotFound();
            }

            return visitorStatistic;
        }

        // PUT: api/VisitorStatistics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitorStatistic(Guid id, VisitorStatistic visitorStatistic)
        {
            if (id != visitorStatistic.Id)
            {
                return BadRequest();
            }

            _context.Entry(visitorStatistic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitorStatisticExists(id))
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

        // POST: api/VisitorStatistics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VisitorStatistic>> PostVisitorStatistic(VisitorStatistic visitorStatistic)
        {
          if (_context.VisitorStatistics == null)
          {
              return Problem("Entity set 'YersinDbContext.VisitorStatistics'  is null.");
          }
            _context.VisitorStatistics.Add(visitorStatistic);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VisitorStatisticExists(visitorStatistic.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVisitorStatistic", new { id = visitorStatistic.Id }, visitorStatistic);
        }

        // DELETE: api/VisitorStatistics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitorStatistic(Guid id)
        {
            if (_context.VisitorStatistics == null)
            {
                return NotFound();
            }
            var visitorStatistic = await _context.VisitorStatistics.FindAsync(id);
            if (visitorStatistic == null)
            {
                return NotFound();
            }

            _context.VisitorStatistics.Remove(visitorStatistic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VisitorStatisticExists(Guid id)
        {
            return (_context.VisitorStatistics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
