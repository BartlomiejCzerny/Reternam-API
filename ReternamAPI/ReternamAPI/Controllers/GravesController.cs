using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReternamApi.Models;

namespace ReternamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GravesController : ControllerBase
    {
        private readonly ReternamContext _context;

        public GravesController(ReternamContext context)
        {
            _context = context;
        }

        // GET: api/Graves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grave>>> GetGraves()
        {
            return await _context.Graves.ToListAsync();
        }

        // GET: api/Graves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grave>> GetGrave(int id)
        {
            var grave = await _context.Graves.FindAsync(id);

            if (grave == null)
            {
                return NotFound();
            }

            return grave;
        }

        // PUT: api/Graves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrave(int id, Grave grave)
        {
            if (id != grave.Id)
            {
                return BadRequest();
            }

            _context.Entry(grave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GraveExists(id))
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

        // POST: api/Graves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Grave>> PostGrave(Grave grave)
        {
            _context.Graves.Add(grave);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrave", new { id = grave.Id }, grave);
        }

        // DELETE: api/Graves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrave(int id)
        {
            var grave = await _context.Graves.FindAsync(id);
            if (grave == null)
            {
                return NotFound();
            }

            _context.Graves.Remove(grave);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GraveExists(int id)
        {
            return _context.Graves.Any(e => e.Id == id);
        }
    }
}
