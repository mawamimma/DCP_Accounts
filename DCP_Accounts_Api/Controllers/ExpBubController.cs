using DCP_Accounts_Api.Data;
using DCP_Accounts_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace DCP_Accounts_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpBubController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ExpBubController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpBub>>> GetAll()
        {
            return await _context.ExpBubs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpBub>> Get(string id)
        {
            var item = await _context.ExpBubs.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<ExpBub>> Create([FromBody] ExpBub expBub)
        {
            _context.ExpBubs.Add(expBub);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = expBub.ExpSubCode }, expBub);
        }
    }
}
