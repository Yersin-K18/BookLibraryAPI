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
    public class SystemConfigsController : ControllerBase
    {
        private readonly YersinDbContext _context;

        public SystemConfigsController(YersinDbContext context)
        {
            _context = context;
        }

        // GET: api/SystemConfigs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemConfig>>> GetSystemConfigs()
        {
          if (_context.SystemConfigs == null)
          {
              return NotFound();
          }
            return await _context.SystemConfigs.ToListAsync();
        }

        // GET: api/SystemConfigs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemConfig>> GetSystemConfig(int id)
        {
          if (_context.SystemConfigs == null)
          {
              return NotFound();
          }
            var systemConfig = await _context.SystemConfigs.FindAsync(id);

            if (systemConfig == null)
            {
                return NotFound();
            }

            return systemConfig;
        }

        // PUT: api/SystemConfigs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemConfig(int id, SystemConfig systemConfig)
        {
            if (id != systemConfig.Id)
            {
                return BadRequest();
            }

            _context.Entry(systemConfig).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemConfigExists(id))
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

        // POST: api/SystemConfigs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SystemConfig>> PostSystemConfig(SystemConfig systemConfig)
        {
          if (_context.SystemConfigs == null)
          {
              return Problem("Entity set 'YersinDbContext.SystemConfigs'  is null.");
          }
            _context.SystemConfigs.Add(systemConfig);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SystemConfigExists(systemConfig.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSystemConfig", new { id = systemConfig.Id }, systemConfig);
        }

        // DELETE: api/SystemConfigs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystemConfig(int id)
        {
            if (_context.SystemConfigs == null)
            {
                return NotFound();
            }
            var systemConfig = await _context.SystemConfigs.FindAsync(id);
            if (systemConfig == null)
            {
                return NotFound();
            }

            _context.SystemConfigs.Remove(systemConfig);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SystemConfigExists(int id)
        {
            return (_context.SystemConfigs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
