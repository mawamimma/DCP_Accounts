using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DCP_Accounts_Api.Data;
using DCP_Accounts_Api.Models;

namespace DCP_Accounts_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncSubController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IncSubController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncSub>>> GetIncSubs()
        {
            return await _context.IncSubs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IncSub>> GetIncSub(int id)
        {
            var item = await _context.IncSubs.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<IncSub>> PostIncSub(IncSub item)
        {
            _context.IncSubs.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetIncSub), new { id = item.IncSubID }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncSub(int id, IncSub item)
        {
            if (id != item.IncSubID) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncSub(int id)
        {
            var item = await _context.IncSubs.FindAsync(id);
            if (item == null) return NotFound();
            _context.IncSubs.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
