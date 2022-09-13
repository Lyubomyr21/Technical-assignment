using Technical_assignment.Data_transfer_objects;
using Technical_assignment.Models;

namespace Technical_assignment.Interfaces
{
    public interface IIncidentService
    {
        public Task<List<Incident>> GetAllIncidents();
        public Task<List<Incident>> CreateIncident(CreateIncidentDto request);
    }
}
