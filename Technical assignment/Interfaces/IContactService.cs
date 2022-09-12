using Technical_assignment.Data_transfer_objects;
using Technical_assignment.Models;

namespace Technical_assignment.Interfaces
{
    public interface IContactService
    {
        public Task<List<Contact>> GetAllContacts();
        public Task<List<Contact>> GetContactsByAccount(int AccountId);
        public Task<List<Contact>> CreateContact(CreateContactDto request);
    }
}
