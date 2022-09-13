using Microsoft.EntityFrameworkCore;
using Technical_assignment.Data_transfer_objects;
using Technical_assignment.Interfaces;
using Technical_assignment.Models;

namespace Technical_assignment.Services
{
    public class ContactService : IContactService
    {
        private DataContext _context;
        private readonly IAccountService _accountService;

        public ContactService(DataContext context, IAccountService accountService)
        {
            _accountService = accountService;
            _context = context;
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<List<Contact>> GetContactsByAccount(int AccountId)
        {
            var contacts = await _context.Contacts
                .Where(x => x.AccountId == AccountId)
                .ToListAsync();

            return contacts;
        }

        public async Task<List<Contact>> CreateContact(ContactAccountDto request)
        {
            var allAccounts = await _accountService.GetAllAccounts();
            var account = await _context.Accounts.FindAsync(request.AccountId);

            var contact = _context.Contacts.ToListAsync().Result.FirstOrDefault(e => e.Email.Equals(request.Email));

            if (contact is not null){
                contact.FirstName = request.FirstName;
                contact.LastName = request.LastName;
                if (contact.Account != account)
                    contact.Account = account;
                else if (allAccounts.Any(x => x.Id != account.Id)){
                    contact.Account = allAccounts.FirstOrDefault(x => x.Id != account.Id);
                }
                else
                {
                    throw new Exception("No fitting account"); 
                }

                await _context.SaveChangesAsync();
                return await GetContactsByAccount(contact.AccountId);
            }
            else
            {
                var newContact = new Contact
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Account = account
                };

                _context.Contacts.Add(newContact);
                await _context.SaveChangesAsync();

                return await GetContactsByAccount(newContact.AccountId);
            }

        }
    }
}
