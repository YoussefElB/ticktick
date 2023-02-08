using Microsoft.AspNetCore.Mvc;
using TickTick.Models;

namespace TickTick.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        static List<Person> people = new List<Person>();

        [HttpGet]
        public IActionResult Get()
        {
            Person person = new Person("Yusup", "Elbu", "elmos@elm.os");
            people.Add(person);
            return Ok(person);
        }
        [HttpGet("{id}")]
        public IActionResult GetId(Guid id)
        {
            var matchedPerson = people.Find(person => person.PublicId == id);
            return Ok(matchedPerson);
        }
    }
}
