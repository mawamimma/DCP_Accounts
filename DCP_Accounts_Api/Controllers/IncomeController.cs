using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DCP_Accounts_Api.Data;
using DCP_Accounts_Api.Models;

namespace DCP_Accounts_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IncomeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Income>>> GetIncomes()
        {
            return await _context.Incomes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Income>> GetIncome(int id)
        {
            var item = await _context.Incomes.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Income>> PostIncome(Income item)
        {
            _context.Incomes.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetIncome), new { id = item.IncomeID }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncome(int id, Income item)
        {
            if (id != item.IncomeID) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncome(int id)
        {
            var item = await _context.Incomes.FindAsync(id);
            if (item == null) return NotFound();
            _context.Incomes.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
