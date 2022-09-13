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
        
        public async Task<List<Account>> CreateAccount(AccountIncidentDto request)
        {
            var incident = await _context.Incidents.FindAsync(request.IncidentId);

            
            var newAccount = new Account
            {
                AccountName = request.AccountName,
                Incident = incident
            };

            _context.Accounts.Add(newAccount);
            await _context.SaveChangesAsync();

            var newContact = new Contact
            {
                FirstName = request.Contact.FirstName,
                LastName = request.Contact.LastName,
                Email = request.Contact.Email,
                Account = newAccount
            };

            _context.Contacts.Add(newContact);
            await _context.SaveChangesAsync();

            return await GetAccountsByIncident(newAccount.IncidentId);
        }
    }
}