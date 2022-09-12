using Microsoft.EntityFrameworkCore;
using Technical_assignment.Data_transfer_objects;
using Technical_assignment.Interfaces;
using Technical_assignment.Models;

namespace Technical_assignment.Services
{
    public class AccountService : IAccountService
    {
        private DataContext _context;
               
        public AccountService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<List<Account>> GetAccountsByIncident(int IncidentId)
        {
            var accounts = await _context.Accounts
                .Where(x => x.IncidentId == IncidentId)
                .ToListAsync();

            return accounts;
        }
    }
}
