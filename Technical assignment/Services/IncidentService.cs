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


            return await GetAllIncidents();

        }
    }
}
