using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Technical_assignment.Interfaces;
using Technical_assignment.Models;

namespace Technical_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IIncidentService _incidentService;

        public IncidentController(DataContext context, IIncidentService incidentService)
        {
            _incidentService = incidentService;
            _context = context;
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<Incident>>> GetAll()
        {
            var incidents = await _incidentService.GetAllIncidents();
            if (incidents == null) return NotFound();
            else return Ok(incidents);
        }
    }
}
