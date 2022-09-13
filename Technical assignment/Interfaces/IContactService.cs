using Technical_assignment.Data_transfer_objects;
using Technical_assignment.Models;

namespace Technical_assignment.Interfaces
{
    public interface IContactService
    {
        public Task<List<Contact>> GetAllContacts();
        public Task<Contact> GetContactById(int id);
        public Task<List<Contact>> GetContactsByAccount(int ContactId);
        public Task<List<Contact>> CreateContact(ContactAccountDto request);
    }
}
