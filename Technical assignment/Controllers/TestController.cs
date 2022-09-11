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
        private static List<TestModel> heroes = new List<TestModel>
            {
                new TestModel {
                    Id = 1,
                    Name ="Spider Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York"
                },
                new TestModel {
                    Id = 2,
                    Name ="Ironman",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Place = "Long Island"
                }
            };

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
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return NotFound("Hero with id="+ id + " Not found");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<TestModel>>> AddHero(TestModel hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<TestModel>>> UpdateHero(TestModel request)
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null)
                return NotFound("Hero with id=" + request.Id + " Not found");
            
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TestModel>> Delete(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return NotFound("Hero with id=" + id + " Not found");

            heroes.Remove(hero);
            return Ok(heroes);
        }
    }
}
