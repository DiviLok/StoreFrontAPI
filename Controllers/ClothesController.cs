﻿using System;
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
    public class ClothesController : ControllerBase
    {
        private readonly ClothContext _context;

        public ClothesController(ClothContext context)
        {
            _context = context;
        }

        // GET: api/Clothes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clothes>>> Getclothes()
        {
            return await _context.clothes.ToListAsync();
        }

        // GET: api/Clothes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clothes>> GetClothes(int id)
        {
            var clothes = await _context.clothes.FindAsync(id);

            if (clothes == null)
            {
                return NotFound();
            }

            return clothes;
        }

        // PUT: api/Clothes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothes(int id, Clothes clothes)
        {
            if (id != clothes.ClothId)
            {
                return BadRequest();
            }

            _context.Entry(clothes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothesExists(id))
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

        // POST: api/Clothes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clothes>> PostClothes(Clothes clothes)
        {
            _context.clothes.Add(clothes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClothes", new { id = clothes.ClothId }, clothes);
        }

        // DELETE: api/Clothes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothes(int id)
        {
            var clothes = await _context.clothes.FindAsync(id);
            if (clothes == null)
            {
                return NotFound();
            }

            _context.clothes.Remove(clothes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClothesExists(int id)
        {
            return _context.clothes.Any(e => e.ClothId == id);
        }
    }
}
