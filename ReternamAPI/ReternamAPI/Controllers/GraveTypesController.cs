using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReternamApi.Models;

namespace ReternamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraveTypesController : ControllerBase
    {
        private readonly ReternamContext _context;

        public GraveTypesController(ReternamContext context)
        {
            _context = context;
        }

        // GET: api/GraveTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GraveType>>> GetGraveTypes()
        {
            return await _context.GraveTypes.ToListAsync();
        }

        // GET: api/GraveTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GraveType>> GetGraveType(int id)
        {
            var graveType = await _context.GraveTypes.FindAsync(id);

            if (graveType == null)
            {
                return NotFound();
            }

            return graveType;
        }

        // PUT: api/GraveTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGraveType(int id, GraveType graveType)
        {
            if (id != graveType.Id)
            {
                return BadRequest();
            }

            _context.Entry(graveType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GraveTypeExists(id))
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

        // POST: api/GraveTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GraveType>> PostGraveType(GraveType graveType)
        {
            _context.GraveTypes.Add(graveType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGraveType", new { id = graveType.Id }, graveType);
        }

        // DELETE: api/GraveTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGraveType(int id)
        {
            var graveType = await _context.GraveTypes.FindAsync(id);
            if (graveType == null)
            {
                return NotFound();
            }

            _context.GraveTypes.Remove(graveType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GraveTypeExists(int id)
        {
            return _context.GraveTypes.Any(e => e.Id == id);
        }
    }
}
