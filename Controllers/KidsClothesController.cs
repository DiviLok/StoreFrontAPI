using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFrontAPI.Model;

namespace StoreFrontAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KidsClothesController : ControllerBase
    {
        private readonly ClothContext _context;

        public KidsClothesController(ClothContext context)
        {
            _context = context;
        }

        // GET: api/KidsClothes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KidsClothes>>> Getkidsclothes()
        {
            return await _context.kidsclothes.ToListAsync();
        }

        // GET: api/KidsClothes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KidsClothes>> GetKidsClothes(int id)
        {
            var kidsClothes = await _context.kidsclothes.FindAsync(id);

            if (kidsClothes == null)
            {
                return NotFound();
            }

            return kidsClothes;
        }

        // PUT: api/KidsClothes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKidsClothes(int id, KidsClothes kidsClothes)
        {
            if (id != kidsClothes.KidClothID)
            {
                return BadRequest();
            }

            _context.Entry(kidsClothes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KidsClothesExists(id))
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

        // POST: api/KidsClothes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KidsClothes>> PostKidsClothes(KidsClothes kidsClothes)
        {
            _context.kidsclothes.Add(kidsClothes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKidsClothes", new { id = kidsClothes.KidClothID }, kidsClothes);
        }

        // DELETE: api/KidsClothes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKidsClothes(int id)
        {
            var kidsClothes = await _context.kidsclothes.FindAsync(id);
            if (kidsClothes == null)
            {
                return NotFound();
            }

            _context.kidsclothes.Remove(kidsClothes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KidsClothesExists(int id)
        {
            return _context.kidsclothes.Any(e => e.KidClothID == id);
        }
    }
}
