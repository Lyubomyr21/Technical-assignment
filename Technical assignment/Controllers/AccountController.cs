using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Technical_assignment.Models;

namespace Technical_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<Account>>> Get()
        {
            return Ok(await _context.Accounts.ToListAsync());
        }

        [HttpGet("ByIncidentId")]
        public async Task<ActionResult<List<Account>>> GetAccountsByIncident(int IncidentId)
        {
            var accounts = await _context.Accounts
                .Where(x => x.IncidentId == IncidentId)
                .ToListAsync();

            return Ok(accounts);
        }
    }
}
