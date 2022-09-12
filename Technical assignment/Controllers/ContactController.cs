using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Technical_assignment.Models;

namespace Technical_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("All")] 
        public async Task<ActionResult<List<Contact>>> Get()
        {
            return Ok(await _context.Contacts.ToListAsync());
        }

        [HttpGet("ByAccountId")]

        public async Task<ActionResult<List<Contact>>> GetContactsByAccount(int AccountId)
        {
            var contacts = await _context.Contacts
                .Where(x => x.AccountId == AccountId)
                .ToListAsync();

            return Ok(contacts);
        }
    
    }
}
