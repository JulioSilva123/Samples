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
    public class StatusRodadasController : ControllerBase
    {
        private readonly db_jornadaquest _context;

        public StatusRodadasController(db_jornadaquest context)
        {
            _context = context;
        }

        // GET: api/StatusRodadas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusRodada>>> GetStatusRodadas()
        {
            return await _context.StatusRodadas.ToListAsync();
        }

        // GET: api/StatusRodadas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusRodada>> GetStatusRodada(int id)
        {
            var statusRodada = await _context.StatusRodadas.FindAsync(id);

            if (statusRodada == null)
            {
                return NotFound();
            }

            return statusRodada;
        }

        // PUT: api/StatusRodadas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusRodada(int id, StatusRodada statusRodada)
        {
            if (id != statusRodada.IdStatusRodada)
            {
                return BadRequest();
            }

            _context.Entry(statusRodada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusRodadaExists(id))
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

        // POST: api/StatusRodadas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusRodada>> PostStatusRodada(StatusRodada statusRodada)
        {
            _context.StatusRodadas.Add(statusRodada);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StatusRodadaExists(statusRodada.IdStatusRodada))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStatusRodada", new { id = statusRodada.IdStatusRodada }, statusRodada);
        }

        // DELETE: api/StatusRodadas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusRodada(int id)
        {
            var statusRodada = await _context.StatusRodadas.FindAsync(id);
            if (statusRodada == null)
            {
                return NotFound();
            }

            _context.StatusRodadas.Remove(statusRodada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusRodadaExists(int id)
        {
            return _context.StatusRodadas.Any(e => e.IdStatusRodada == id);
        }
    }
}
