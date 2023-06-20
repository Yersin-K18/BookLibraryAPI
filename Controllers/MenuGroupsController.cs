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
    public class MenuGroupsController : ControllerBase
    {
        private readonly YersinDbContext _context;

        public MenuGroupsController(YersinDbContext context)
        {
            _context = context;
        }

        // GET: api/MenuGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuGroup>>> GetMenuGroups()
        {
          if (_context.MenuGroups == null)
          {
              return NotFound();
          }
            return await _context.MenuGroups.ToListAsync();
        }

        // GET: api/MenuGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuGroup>> GetMenuGroup(int id)
        {
          if (_context.MenuGroups == null)
          {
              return NotFound();
          }
            var menuGroup = await _context.MenuGroups.FindAsync(id);

            if (menuGroup == null)
            {
                return NotFound();
            }

            return menuGroup;
        }

        // PUT: api/MenuGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuGroup(int id, MenuGroup menuGroup)
        {
            if (id != menuGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(menuGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuGroupExists(id))
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

        // POST: api/MenuGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MenuGroup>> PostMenuGroup(MenuGroup menuGroup)
        {
          if (_context.MenuGroups == null)
          {
              return Problem("Entity set 'YersinDbContext.MenuGroups'  is null.");
          }
            _context.MenuGroups.Add(menuGroup);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MenuGroupExists(menuGroup.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMenuGroup", new { id = menuGroup.Id }, menuGroup);
        }

        // DELETE: api/MenuGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuGroup(int id)
        {
            if (_context.MenuGroups == null)
            {
                return NotFound();
            }
            var menuGroup = await _context.MenuGroups.FindAsync(id);
            if (menuGroup == null)
            {
                return NotFound();
            }

            _context.MenuGroups.Remove(menuGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuGroupExists(int id)
        {
            return (_context.MenuGroups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
