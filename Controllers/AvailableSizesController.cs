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
    public class AvailableSizesController : ControllerBase
    {
        private readonly ClothContext _context;

        public AvailableSizesController(ClothContext context)
        {
            _context = context;
        }

        // GET: api/AvailableSizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvailableSize>>> GetavailableSizes()
        {
            return await _context.availableSizes.ToListAsync();
        }

        // GET: api/AvailableSizes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AvailableSize>> GetAvailableSize(int id)
        {
            var availableSize = await _context.availableSizes.FindAsync(id);

            if (availableSize == null)
            {
                return NotFound();
            }

            return availableSize;
        }

        // PUT: api/AvailableSizes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvailableSize(int id, AvailableSize availableSize)
        {
            if (id != availableSize.SizeID)
            {
                return BadRequest();
            }

            _context.Entry(availableSize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvailableSizeExists(id))
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

        // POST: api/AvailableSizes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AvailableSize>> PostAvailableSize(AvailableSize availableSize)
        {
            _context.availableSizes.Add(availableSize);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvailableSize", new { id = availableSize.SizeID }, availableSize);
        }

        // DELETE: api/AvailableSizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvailableSize(int id)
        {
            var availableSize = await _context.availableSizes.FindAsync(id);
            if (availableSize == null)
            {
                return NotFound();
            }

            _context.availableSizes.Remove(availableSize);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvailableSizeExists(int id)
        {
            return _context.availableSizes.Any(e => e.SizeID == id);
        }
    }
}
