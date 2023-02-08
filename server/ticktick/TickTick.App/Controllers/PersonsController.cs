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
            List<Location> adressList = new List<Location>
            {
                new Location("Generaal de witte laan", "Mechelen", "1244", "België", "3"),
                new Location("Generaal de Rode laan", "Mechelen", "4124", "België", "2"),
                new Location("Generaal de Blauwe laan", "Mechelen", "643", "België", "1")
            };

            Person person = new Person("Yusup", "Elbu", "elmos@elm.os", adressList);
            people.Add(person);
            return Ok(person);
        }
        [HttpGet("{id}")]
        public IActionResult GetId(Guid id)
        {
            var matchedPerson = people.Find(person => person.PublicId == id);
            return Ok(Person.ConvertToDto(matchedPerson));
        }
    }
}
