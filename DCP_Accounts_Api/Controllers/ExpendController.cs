using DCP_Accounts_Api.Data;
using DCP_Accounts_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace DCP_Accounts_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpendController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ExpendController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expend>>> GetAll()
        {
            return await _db.Expends.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Expend>> Get(int id)
        {
            var item = await _db.Expends.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Expend>> Create([FromBody] Expend expend)
        {
            if (expend == null) return BadRequest();
            if (!expend.EntryDate.HasValue)
                expend.EntryDate = DateTime.UtcNow;

            _db.Expends.Add(expend);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = expend.ExpenditurID }, expend);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Expend expend)
        {
            if (id != expend.ExpenditurID) return BadRequest();
            _db.Entry(expend).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.Expends.FindAsync(id);
            if (item == null) return NotFound();
            _db.Expends.Remove(item);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
