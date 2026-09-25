using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DBContext;
using Services.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadesController : ControllerBase
    {
        private readonly InventarioContext _context;


        public LocalidadesController(InventarioContext context)
        {
            _context = context;
        }

        // GET: api/Localidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Localidad>>> GetLocalidades([FromQuery] string filtro = "")
        {
            filtro = filtro.ToUpper();
            return await _context.Localidades
            .Include(l => l.Provincia)
            .ThenInclude(p => p.Pais)
            .Where(c => c.Name.ToUpper().Contains(filtro))
            .OrderBy(c => c.Name)
            .ToListAsync();
        }

        // GET: api/Localidades
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Localidad>>> GetLocalidades()
        //{
        //    return await _context.Localidades
        //    .Include(l => l.Provincia)
        //    .ThenInclude(p => p.Pais)
        //    .ToListAsync();
        //}

        // GET: api/Localidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Localidad>> GetLocalidad(int id)
        {
            var localidad = await _context.Localidades
            .Include(l => l.Provincia)
            .ThenInclude(p => p.Pais)
            .FirstOrDefaultAsync(l => l.Id == id);

            if (localidad == null)
            {
                return NotFound();
            }

            return localidad;
        }
        [HttpGet ("Total")]
        public async Task<ActionResult<int>> GetTotalLocalidades()
        {
            return await _context.Localidades.CountAsync(l => !l.IsDeleted);
        }

        // PUT: api/Localidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalidad(int id, Localidad localidad)
        {
            if (id != localidad.Id)
            {
                return BadRequest();
            }

            _context.Entry(localidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalidadExists(id))
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

        [HttpGet("Deleteds")]
        public async Task<ActionResult<IEnumerable<Localidad>>> GetDeleted()
        {
            return await _context.Localidades
            .IgnoreQueryFilters()
            .Include(l => l.Provincia)
            .ThenInclude(p => p.Pais)
            .Where(c => c.IsDeleted)
            .ToListAsync();
        }

        // POST: api/Localidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Localidad>> PostLocalidad(Localidad localidad)
        {
            _context.Localidades.Add(localidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocalidad", new { id = localidad.Id }, localidad);
        }

        // DELETE: api/Localidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalidad(int id)
        {
            var localidad = await _context.Localidades.FindAsync(id);
            if (localidad == null)
            {
                return NotFound();
            }
            localidad.IsDeleted = true;
            _context.Entry(localidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreLocalidad(int id)
        {
            var localidad = await _context.Localidades
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (localidad == null)
            {
                return NotFound();
            }
            localidad.IsDeleted = false;
            _context.Entry(localidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocalidadExists(int id)
        {
            return _context.Localidades.Any(e => e.Id == id);
        }
    }
}