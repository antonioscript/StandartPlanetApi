using DockerPlanet.DataContext;
using DockerPlanet.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerPlanet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlanetsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Planets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planet>>> GetPlanets()
        {
            if (_context.Planets == null)
            {
                return NotFound();
            }
            return await _context.Planets.ToListAsync();
        }

        // GET: api/Planets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Planet>> GetPlanet(int id)
        {
            if (_context.Planets == null)
            {
                return NotFound();
            }
            var Planet = await _context.Planets.FindAsync(id);

            if (Planet == null)
            {
                return NotFound();
            }

            return Planet;
        }

        // PUT: api/Planets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanet(int id, Planet Planet)
        {
            if (id != Planet.Id)
            {
                return BadRequest();
            }

            _context.Entry(Planet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanetExists(id))
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

        // POST: api/Planets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Planet>> PostPlanet(Planet Planet)
        {
            if (_context.Planets == null)
            {
                return Problem("Entity set 'AppDbContext.Planets'  is null.");
            }
            _context.Planets.Add(Planet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanet", new { id = Planet.Id }, Planet);
        }

        // DELETE: api/Planets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanet(int id)
        {
            if (_context.Planets == null)
            {
                return NotFound();
            }
            var Planet = await _context.Planets.FindAsync(id);
            if (Planet == null)
            {
                return NotFound();
            }

            _context.Planets.Remove(Planet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanetExists(int id)
        {
            return (_context.Planets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}