using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarWash.Data;
using CarWash.Models;
using Microsoft.AspNetCore.Cors;

namespace CarWash.Controllers
{
    [Route("v1/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    [ApiController]
    public class CarWashController : ControllerBase
    {
        private readonly CarWashDbContext _context;

        public CarWashController(CarWashDbContext context)
        {
            _context = context;
        }

        // GET: api/CarWash
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarWashModel>>> GetCarWash()
        {
          if (_context.CarWash == null)
          {
              return NotFound();
          }
            return await _context.CarWash.ToListAsync();
        }

        // GET: api/CarWash/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarWashModel>> GetCarWashModel(int id)
        {
          if (_context.CarWash == null)
          {
              return NotFound();
          }
            var carWashModel = await _context.CarWash.FindAsync(id);

            if (carWashModel == null)
            {
                return NotFound();
            }

            return carWashModel;
        }

        // PUT: api/CarWash/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarWashModel(int id, CarWashModel carWashModel)
        {
            if (id != carWashModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(carWashModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarWashModelExists(id))
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

        // POST: api/CarWash
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarWashModel>> PostCarWashModel(CarWashModel carWashModel)
        {
          if (_context.CarWash == null)
          {
              return Problem("Entity set 'CarWashDbContext.CarWash'  is null.");
          }
            _context.CarWash.Add(carWashModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarWashModel", new { id = carWashModel.Id }, carWashModel);
        }

        // DELETE: api/CarWash/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarWashModel(int id)
        {
            if (_context.CarWash == null)
            {
                return NotFound();
            }
            var carWashModel = await _context.CarWash.FindAsync(id);
            if (carWashModel == null)
            {
                return NotFound();
            }

            _context.CarWash.Remove(carWashModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarWashModelExists(int id)
        {
            return (_context.CarWash?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
