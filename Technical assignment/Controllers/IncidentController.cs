using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Technical_assignment.Models;

namespace Technical_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly DataContext _context;

        public IncidentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<Incident>>> Get()
        {
            return Ok(await _context.Incidents.ToListAsync());
        }
    }
}
