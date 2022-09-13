﻿using Microsoft.EntityFrameworkCore;
using Technical_assignment.Data_transfer_objects;
using Technical_assignment.Interfaces;
using Technical_assignment.Models;

namespace Technical_assignment.Services
{
    public class ContactService : IContactService
    {
        private DataContext _context;
               
        public ContactService(DataContext context)
        {
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
            var account = await _context.Accounts.FindAsync(request.AccountId);

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
