using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameJornadaQuest.Server.Data;

namespace GameJornadaQuest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensRodadasController : ControllerBase
    {
        private readonly db_jornadaquest _context;

        public ItensRodadasController(db_jornadaquest context)
        {
            _context = context;
        }

        // GET: api/ItensRodadas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItensRodada>>> GetItensRodadas()
        {
            return await _context.ItensRodadas.ToListAsync();
        }

        // GET: api/ItensRodadas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItensRodada>> GetItensRodada(int id)
        {
            var itensRodada = await _context.ItensRodadas.FindAsync(id);

            if (itensRodada == null)
            {
                return NotFound();
            }

            return itensRodada;
        }

        // PUT: api/ItensRodadas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItensRodada(int id, ItensRodada itensRodada)
        {
            if (id != itensRodada.IdItemRodada)
            {
                return BadRequest();
            }

            _context.Entry(itensRodada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItensRodadaExists(id))
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

        // POST: api/ItensRodadas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItensRodada>> PostItensRodada(ItensRodada itensRodada)
        {
            _context.ItensRodadas.Add(itensRodada);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItensRodadaExists(itensRodada.IdItemRodada))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetItensRodada", new { id = itensRodada.IdItemRodada }, itensRodada);
        }

        // DELETE: api/ItensRodadas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItensRodada(int id)
        {
            var itensRodada = await _context.ItensRodadas.FindAsync(id);
            if (itensRodada == null)
            {
                return NotFound();
            }

            _context.ItensRodadas.Remove(itensRodada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItensRodadaExists(int id)
        {
            return _context.ItensRodadas.Any(e => e.IdItemRodada == id);
        }
    }
}
