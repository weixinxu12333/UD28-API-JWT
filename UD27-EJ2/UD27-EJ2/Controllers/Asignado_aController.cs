using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UD27_EJ2.Models;

namespace UD27_EJ2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Asignado_aController : ControllerBase
    {
        private readonly APIContext _context;

        public Asignado_aController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Asignado_a
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asignado_a>>> GetAsignado_as()
        {
            return await _context.Asignado_as.ToListAsync();
        }

        // GET: api/Asignado_a/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asignado_a>> GetAsignado_a(string id)
        {
            var asignado_a = await _context.Asignado_as.FindAsync(id);

            if (asignado_a == null)
            {
                return NotFound();
            }

            return asignado_a;
        }

        // PUT: api/Asignado_a/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignado_a(string id, Asignado_a asignado_a)
        {
            if (id != asignado_a.Proyecto)
            {
                return BadRequest();
            }

            _context.Entry(asignado_a).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Asignado_aExists(id))
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

        // POST: api/Asignado_a
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Asignado_a>> PostAsignado_a(Asignado_a asignado_a)
        {
            _context.Asignado_as.Add(asignado_a);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Asignado_aExists(asignado_a.Proyecto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAsignado_a", new { id = asignado_a.Proyecto }, asignado_a);
        }

        // DELETE: api/Asignado_a/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Asignado_a>> DeleteAsignado_a(string id)
        {
            var asignado_a = await _context.Asignado_as.FindAsync(id);
            if (asignado_a == null)
            {
                return NotFound();
            }

            _context.Asignado_as.Remove(asignado_a);
            await _context.SaveChangesAsync();

            return asignado_a;
        }

        private bool Asignado_aExists(string id)
        {
            return _context.Asignado_as.Any(e => e.Proyecto == id);
        }
    }
}
