using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeuroTrack.Data;
using NeuroTrack.Models;

namespace NeuroTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MomentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MomentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Moments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moment>>> GetMoments()
        {
            return await _context.Moments.ToListAsync();
        }

        // GET: api/Moments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Moment>> GetMoment(int id)
        {
            var moment = await _context.Moments.FindAsync(id);

            if (moment == null)
            {
                return NotFound();
            }

            return moment;
        }

        // PUT: api/Moments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoment(int id, Moment moment)
        {
            if (id != moment.MomentId)
            {
                return BadRequest();
            }

            _context.Entry(moment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MomentExists(id))
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

        // POST: api/Moments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Moment>> PostMoment(Moment moment)
        {
            _context.Moments.Add(moment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMoment", new { id = moment.MomentId }, moment);
        }

        // DELETE: api/Moments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoment(int id)
        {
            var moment = await _context.Moments.FindAsync(id);
            if (moment == null)
            {
                return NotFound();
            }

            _context.Moments.Remove(moment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MomentExists(int id)
        {
            return _context.Moments.Any(e => e.MomentId == id);
        }
    }
}
