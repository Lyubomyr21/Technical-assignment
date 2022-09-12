using Microsoft.EntityFrameworkCore;
using Technical_assignment.Data_transfer_objects;
using Technical_assignment.Interfaces;
using Technical_assignment.Models;

namespace Technical_assignment.Services
{
    public class IncidentService : IIncidentService
    {
        private DataContext _context;
               
        public IncidentService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Incident>> GetAllIncidents()
        {
            return await _context.Incidents.ToListAsync();
        }
    }
}
