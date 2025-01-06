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
    public class RodadasController : ControllerBase
    {
        private readonly db_jornadaquest _context;

        public RodadasController(db_jornadaquest context)
        {
            _context = context;
        }

        // GET: api/Rodadas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rodada>>> GetRodadas()
        {
            return await _context.Rodadas.ToListAsync();
        }

        // GET: api/Rodadas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rodada>> GetRodada(int id)
        {
            var rodada = await _context.Rodadas.FindAsync(id);

            if (rodada == null)
            {
                return NotFound();
            }

            return rodada;
        }

        // PUT: api/Rodadas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRodada(int id, Rodada rodada)
        {
            if (id != rodada.IdRodada)
            {
                return BadRequest();
            }

            _context.Entry(rodada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RodadaExists(id))
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

        // POST: api/Rodadas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rodada>> PostRodada(Rodada rodada)
        {
            _context.Rodadas.Add(rodada);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RodadaExists(rodada.IdRodada))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRodada", new { id = rodada.IdRodada }, rodada);
        }

        // DELETE: api/Rodadas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRodada(int id)
        {
            var rodada = await _context.Rodadas.FindAsync(id);
            if (rodada == null)
            {
                return NotFound();
            }

            _context.Rodadas.Remove(rodada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RodadaExists(int id)
        {
            return _context.Rodadas.Any(e => e.IdRodada == id);
        }
    }
}
