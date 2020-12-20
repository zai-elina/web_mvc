using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopCosmetic.Data;
using ShopCosmetic.Data.Models;

namespace ShopCosmetic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CosmeticsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public CosmeticsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Cosmetics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cosmetic>>> GetCosmetic()
        {
            return await _context.Cosmetic.ToListAsync();
        }

        // GET: api/Cosmetics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cosmetic>> GetCosmetic(int id)
        {
            var cosmetic = await _context.Cosmetic.FindAsync(id);

            if (cosmetic == null)
            {
                return NotFound();
            }

            return cosmetic;
        }

        // PUT: api/Cosmetics/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCosmetic(int id, Cosmetic cosmetic)
        {
            if (id != cosmetic.CosmeticId)
            {
                return BadRequest();
            }

            _context.Entry(cosmetic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CosmeticExists(id))
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

        // POST: api/Cosmetics
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cosmetic>> PostCosmetic(Cosmetic cosmetic)
        {
            _context.Cosmetic.Add(cosmetic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCosmetic", new { id = cosmetic.CosmeticId }, cosmetic);
        }

        // DELETE: api/Cosmetics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cosmetic>> DeleteCosmetic(int id)
        {
            var cosmetic = await _context.Cosmetic.FindAsync(id);
            if (cosmetic == null)
            {
                return NotFound();
            }

            _context.Cosmetic.Remove(cosmetic);
            await _context.SaveChangesAsync();

            return cosmetic;
        }

        private bool CosmeticExists(int id)
        {
            return _context.Cosmetic.Any(e => e.CosmeticId == id);
        }
    }
}
