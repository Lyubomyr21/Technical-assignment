using Microsoft.EntityFrameworkCore;
using Technical_assignment.Data_transfer_objects;
using Technical_assignment.Interfaces;
using Technical_assignment.Models;

namespace Technical_assignment.Services
{
    public class IncidentService : IIncidentService
    {
        private DataContext _context;
        private readonly IContactService _contactService;
        private readonly IAccountService _accountService;

        public IncidentService(DataContext context, IContactService contactService, IAccountService accountService)
        {
            _accountService = accountService;
            _contactService = contactService;
            _context = context;
        }

        public async Task<List<Incident>> GetAllIncidents()
        {
            return await _context.Incidents.ToListAsync();
        }

        public async Task<List<Incident>> CreateIncident(IncidentDto request)
        {
            var newIncident = new Incident
            {
                IncidentName = request.IncidentName,
            };

            _context.Incidents.Add(newIncident);
            await _context.SaveChangesAsync();

            var newAccount = new Account
            {
                AccountName = request.Account.AccountName,
                Incident = newIncident
            };

            _context.Accounts.Add(newAccount);

            var allAccounts = await _accountService.GetAllAccounts();
            var account = newAccount;
            var contact = _context.Contacts.ToListAsync().Result.FirstOrDefault(e => e.Email.Equals(request.Contact.Email));

            if (contact is not null)
            {
                contact.FirstName = request.Contact.FirstName;
                contact.LastName = request.Contact.LastName;
                if (contact.Account != account)
                {
                    contact.Account = account;
                }
                else if (allAccounts.Any(x => x.Id != account.Id))
                {
                    contact.Account = allAccounts.FirstOrDefault(x => x.Id != account.Id);
                }
                else
                {
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

            //await _context.SaveChangesAsync();

            //var newContact = new Contact
            //{
            //    FirstName = request.Contact.FirstName,
            //    LastName = request.Contact.LastName,
            //    Email = request.Contact.Email,
            //    Account = newAccount
            //};

            //_context.Contacts.Add(newContact);
            //await _context.SaveChangesAsync();


            return await GetAllIncidents();

        }
    }
}
