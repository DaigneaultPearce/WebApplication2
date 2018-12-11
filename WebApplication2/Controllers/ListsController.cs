using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListsController : ControllerBase
    {
        private readonly todoappContext _context;

        public ListsController(todoappContext context)
        {
            _context = context;
        }

        // GET: api/Lists
        [HttpGet]
        public IEnumerable<Lists> GetLists()
        {
            return _context.Lists;
        }

        // GET: api/Lists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLists([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lists = await _context.Lists.FindAsync(id);

            if (lists == null)
            {
                return NotFound();
            }

            return Ok(lists);
        }

        // PUT: api/Lists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLists([FromRoute] int id, [FromBody] Lists lists)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lists.Id)
            {
                return BadRequest();
            }

            _context.Entry(lists).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListsExists(id))
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

        // POST: api/Lists
        [HttpPost]
        public async Task<IActionResult> PostLists([FromBody] Lists lists)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Lists.Add(lists);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ListsExists(lists.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLists", new { id = lists.Id }, lists);
        }

        // DELETE: api/Lists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLists([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lists = await _context.Lists.FindAsync(id);
            if (lists == null)
            {
                return NotFound();
            }

            _context.Lists.Remove(lists);
            await _context.SaveChangesAsync();

            return Ok(lists);
        }

        private bool ListsExists(int id)
        {
            return _context.Lists.Any(e => e.Id == id);
        }
    }
}