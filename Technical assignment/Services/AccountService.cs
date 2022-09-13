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
            var allAccounts = await GetAllAccounts();

            var newAccount = new Account
            {
                AccountName = request.AccountName,
                Incident = incident
            };

            var account = newAccount;
            var contact = _context.Contacts.ToListAsync().Result.FirstOrDefault(e => e.Email.Equals(request.Contact.Email));

            if (contact is not null)
            {
                contact.FirstName = request.Contact.FirstName;
                contact.LastName = request.Contact.LastName;
                if (contact.Account != account){
                    contact.Account = account;
                }
                else if (allAccounts.Any(x => x.Id != account.Id)){
                    contact.Account = allAccounts.FirstOrDefault(x => x.Id != account.Id);
                }
                else{
                    throw new Exception("No fitting account");
                }

                await _context.SaveChangesAsync();
            }
            else
            {
                var newContact = new Contact
                {
                    FirstName = request.Contact.FirstName,
                    LastName = request.Contact.LastName,
                    Email = request.Contact.Email,
                    Account = account
                };

                _context.Contacts.Add(newContact);
                await _context.SaveChangesAsync();
            }

            return await GetAccountsByIncident(newAccount.IncidentId);
        }
    }
}