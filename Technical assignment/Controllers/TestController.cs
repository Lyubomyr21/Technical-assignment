using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Technical_assignment.Models;

namespace Technical_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TestModel>>> Get()
        {
            var heroes = new List<TestModel>
            {
                new TestModel { 
                    Id = 1, 
                    Name ="Spider Man", 
                    FirstName = "Peter", 
                    LastName = "Parker", 
                    Place = "New York City"
                }
            };

            return Ok(heroes);
        }
    }
}
