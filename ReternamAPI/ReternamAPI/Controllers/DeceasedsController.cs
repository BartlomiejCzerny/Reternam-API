using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReternamApi.Models;

namespace ReternamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeceasedsController : ControllerBase
    {
        private readonly ReternamContext _context;

        public DeceasedsController(ReternamContext context)
        {
            _context = context;
        }

        // GET: api/Deceaseds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deceased>>> GetDeceaseds()
        {
            return await _context.Deceaseds.ToListAsync();
        }

        // GET: api/Deceaseds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deceased>> GetDeceased(int id)
        {
            var deceased = await _context.Deceaseds.FindAsync(id);

            if (deceased == null)
            {
                return NotFound();
            }

            return deceased;
        }

        // PUT: api/Deceaseds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeceased(int id, Deceased deceased)
        {
            if (id != deceased.Id)
            {
                return BadRequest();
            }

            _context.Entry(deceased).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeceasedExists(id))
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

        // POST: api/Deceaseds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deceased>> PostDeceased(Deceased deceased)
        {
            _context.Deceaseds.Add(deceased);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeceased", new { id = deceased.Id }, deceased);
        }

        // DELETE: api/Deceaseds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeceased(int id)
        {
            var deceased = await _context.Deceaseds.FindAsync(id);
            if (deceased == null)
            {
                return NotFound();
            }

            _context.Deceaseds.Remove(deceased);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeceasedExists(int id)
        {
            return _context.Deceaseds.Any(e => e.Id == id);
        }
    }
}
