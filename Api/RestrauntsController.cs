using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestrauntsController : ControllerBase
    {
        private readonly OdeFoodDbContext _context;

        public RestrauntsController(OdeFoodDbContext context)
        {
            _context = context;
        }

        // GET: api/Restraunts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restraunt>>> GetRestrauns()
        {
            return await _context.Restrauns.ToListAsync();
        }

        // GET: api/Restraunts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restraunt>> GetRestraunt(int id)
        {
            var restraunt = await _context.Restrauns.FindAsync(id);

            if (restraunt == null)
            {
                return NotFound();
            }

            return restraunt;
        }

        // PUT: api/Restraunts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestraunt(int id, Restraunt restraunt)
        {
            if (id != restraunt.Id)
            {
                return BadRequest();
            }

            _context.Entry(restraunt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestrauntExists(id))
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

        // POST: api/Restraunts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Restraunt>> PostRestraunt(Restraunt restraunt)
        {
            _context.Restrauns.Add(restraunt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestraunt", new { id = restraunt.Id }, restraunt);
        }

        // DELETE: api/Restraunts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Restraunt>> DeleteRestraunt(int id)
        {
            var restraunt = await _context.Restrauns.FindAsync(id);
            if (restraunt == null)
            {
                return NotFound();
            }

            _context.Restrauns.Remove(restraunt);
            await _context.SaveChangesAsync();

            return restraunt;
        }

        private bool RestrauntExists(int id)
        {
            return _context.Restrauns.Any(e => e.Id == id);
        }
    }
}
