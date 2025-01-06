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
    public class ItensRodadaClicksController : ControllerBase
    {
        private readonly db_jornadaquest _context;

        public ItensRodadaClicksController(db_jornadaquest context)
        {
            _context = context;
        }

        // GET: api/ItensRodadaClicks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItensRodadaClick>>> GetItensRodadaClicks()
        {
            return await _context.ItensRodadaClicks.ToListAsync();
        }

        // GET: api/ItensRodadaClicks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItensRodadaClick>> GetItensRodadaClick(int id)
        {
            var itensRodadaClick = await _context.ItensRodadaClicks.FindAsync(id);

            if (itensRodadaClick == null)
            {
                return NotFound();
            }

            return itensRodadaClick;
        }

        // PUT: api/ItensRodadaClicks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItensRodadaClick(int id, ItensRodadaClick itensRodadaClick)
        {
            if (id != itensRodadaClick.IdItemRodadaClick)
            {
                return BadRequest();
            }

            _context.Entry(itensRodadaClick).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItensRodadaClickExists(id))
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

        // POST: api/ItensRodadaClicks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItensRodadaClick>> PostItensRodadaClick(ItensRodadaClick itensRodadaClick)
        {
            _context.ItensRodadaClicks.Add(itensRodadaClick);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItensRodadaClickExists(itensRodadaClick.IdItemRodadaClick))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetItensRodadaClick", new { id = itensRodadaClick.IdItemRodadaClick }, itensRodadaClick);
        }

        // DELETE: api/ItensRodadaClicks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItensRodadaClick(int id)
        {
            var itensRodadaClick = await _context.ItensRodadaClicks.FindAsync(id);
            if (itensRodadaClick == null)
            {
                return NotFound();
            }

            _context.ItensRodadaClicks.Remove(itensRodadaClick);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItensRodadaClickExists(int id)
        {
            return _context.ItensRodadaClicks.Any(e => e.IdItemRodadaClick == id);
        }
    }
}
