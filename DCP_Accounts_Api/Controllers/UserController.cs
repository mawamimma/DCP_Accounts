using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DCP_Accounts_Api.Data;
using DCP_Accounts_Api.Models;

namespace DCP_Accounts_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var item = await _context.Users.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User item)
        {
            _context.Users.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = item.UserID }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>
    }
}
