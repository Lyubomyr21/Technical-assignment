using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Technical_assignment.Interfaces;
using Technical_assignment.Models;

namespace Technical_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IAccountService _accountService;

        public AccountController(DataContext context, IAccountService accountService)
        {
            _accountService = accountService;
            _context = context;
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<Account>>> GetAll()
        {
            var accounts = await _accountService.GetAllAccounts();
            if (accounts == null) return NotFound();
            else return Ok(accounts);
        }

        [HttpGet("ByIncidentId")]
        public async Task<ActionResult<List<Account>>> GetAccountsByIncident(int Id)
        {
            var contacts = await _accountService.GetAccountsByIncident(Id);
            if (contacts == null) return NotFound();
            else return Ok(contacts);
        }
    }
}
