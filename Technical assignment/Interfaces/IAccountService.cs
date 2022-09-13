using Technical_assignment.Data_transfer_objects;
using Technical_assignment.Models;

namespace Technical_assignment.Interfaces
{
    public interface IAccountService
    {
        public Task<List<Account>> GetAllAccounts();
        public Task<List<Account>> GetAccountsByIncident(int IncidentId);
        public Task<List<Account>> CreateAccount(CreateAccountDto request);
    }
}
