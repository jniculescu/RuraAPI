using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuralAPI.Models;

namespace RuralAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummariesController : ControllerBase
    {
        private readonly Ruraldb2Context _context;

        public SummariesController(Ruraldb2Context context)
        {
            _context = context;
        }

        // GET: api/Summaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Summary>>> GetSummary()
        {
            return await _context.Summary.ToListAsync();
        }

        // GET: api/Summaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Summary>> GetSummary(long id)
        {
            var summary = await _context.Summary.FindAsync(id);

            if (summary == null)
            {
                return NotFound();
            }

            return summary;
        }

        // PUT: api/Summaries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSummary(long id, Summary summary)
        {
            if (id != summary.SummaryId)
            {
                return BadRequest();
            }

            _context.Entry(summary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SummaryExists(id))
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

        // POST: api/Summaries
        [HttpPost]
        public async Task<ActionResult<Summary>> PostSummary(Summary summary)
        {
            _context.Summary.Add(summary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSummary", new { id = summary.SummaryId }, summary);
        }

        // DELETE: api/Summaries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Summary>> DeleteSummary(long id)
        {
            var summary = await _context.Summary.FindAsync(id);
            if (summary == null)
            {
                return NotFound();
            }

            _context.Summary.Remove(summary);
            await _context.SaveChangesAsync();

            return summary;
        }

        private bool SummaryExists(long id)
        {
            return _context.Summary.Any(e => e.SummaryId == id);
        }
    }
}
