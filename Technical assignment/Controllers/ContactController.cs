using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Technical_assignment.Data_transfer_objects;
using Technical_assignment.Interfaces;
using Technical_assignment.Models;

namespace Technical_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IContactService _contactService;

        public ContactController(DataContext context, IContactService contactService)
        {
            _contactService = contactService;
            _context = context;
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<Contact>>> GetAll()
        {
            var contacts = await _contactService.GetAllContacts();
            if (contacts == null) return NotFound();
            else return Ok(contacts);
        }

        [HttpGet("id")]

        public async Task<ActionResult<List<Contact>>> Get(int Id)
        {
            var contacts = await _contactService.GetContactsByAccount(Id);
            if (contacts == null) return NotFound();
            else return Ok(contacts);
        }

        [HttpPost]
        public async Task<ActionResult<List<Contact>>> Create(CreateContactDto request)
        {
            var contacts = await _contactService.CreateContact(request);
            if (contacts == null) return NotFound();
            else return Ok(contacts);
        }
    }
}
