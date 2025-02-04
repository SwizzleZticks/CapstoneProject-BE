using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capstone_BE.Models;  

namespace Capstone_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly CapstoneDbContext _context;  

        public LocationController(CapstoneDbContext context)
        {
            _context = context;
        }

        // Update
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateLocation(short id, [FromBody] Location updatedLocation)
        {
            if (id != updatedLocation.LocationId)
            {
                return BadRequest();  
            }

            _context.Entry(updatedLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))  
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

        //delete
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteLocation(short id)
        {
            var location = await _context.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();  
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return NoContent();  
        }

        
        private bool LocationExists(short id)
        {
            return _context.Locations.Any(e => e.LocationId == id);
        }
    }
}
