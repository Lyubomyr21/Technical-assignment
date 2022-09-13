using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Technical_assignment.Data_transfer_objects;
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

        [HttpGet("ById")]
        public async Task<ActionResult<Contact>> GetAccount(int Id)
        {
            var account = await _accountService.GetAccountByID(Id);
            if (account == null) return NotFound();
            else return Ok(account);
        }

        [HttpGet("ByAccountName")]
        public async Task<ActionResult<Contact>> GetAccountByName(string AccountName)
        {
            var account = await _accountService.GetAccountByAccountName(AccountName);
            if (account == null) return NotFound();
            else return Ok(account);
        }

        [HttpGet("ByIncidentId")]
        public async Task<ActionResult<List<Account>>> GetAccountsByIncident(int Id)
        {
            var contacts = await _accountService.GetAccountsByIncident(Id);
            if (contacts == null) return NotFound();
            else return Ok(contacts);
        }


        [HttpPost]
        public async Task<ActionResult<List<Account>>> Create(AccountIncidentDto request)
        {
            var accounts = await _accountService.CreateAccount(request);

            if (accounts == null) return NotFound();
            else return Ok(accounts);
        }
    }
}
