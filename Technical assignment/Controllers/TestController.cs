using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Technical_assignment.Data;
using Technical_assignment.Models;

namespace Technical_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly DataContext _context;

        public TestController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TestModel>>> Get()
        {
            return Ok(await _context.testModels.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestModel>> Get(int id)
        {
            var hero = await _context.testModels.FindAsync(id);
            if (hero == null)
                return NotFound("Hero with id="+ id + " Not found");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<TestModel>>> AddHero(TestModel hero)
        {
            _context.testModels.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.testModels.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<TestModel>>> UpdateHero(TestModel request)
        {
            var dbHero = await _context.testModels.FindAsync(request.Id);
            if (dbHero == null)
                return NotFound("Hero with id=" + request.Id + " Not found");

            dbHero.Name = request.Name;
            dbHero.FirstName = request.FirstName;
            dbHero.LastName = request.LastName;
            dbHero.Place = request.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.testModels.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TestModel>> Delete(int id)
        {
            var hero = await _context.testModels.FindAsync(id);
            if (hero == null)
                return NotFound("Hero with id=" + id + " Not found");

            _context.testModels.Remove(hero);

            await _context.SaveChangesAsync();

            return Ok(await _context.testModels.ToListAsync());
        }
    }
}
