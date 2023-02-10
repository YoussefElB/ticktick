using Microsoft.AspNetCore.Mvc;
using TickTick.App.ResponseWrappers;
using TickTick.App.Services;
using TickTick.Models;

namespace TickTick.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        static List<Person> people = new List<Person>();
        private readonly IPersonsService svc;

        public PersonsController(IPersonsService personService)
        {
             svc = svc;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(PersonDto), 200)]
        public IActionResult Get()
        {
            try
            {
                Response<IEnumerable<Person>> response = new Response<IEnumerable<Person>>();
                response.Data = people;
                return Ok(response);
            }
            catch (Exception e)
            {
                Response<IEnumerable<Person>> errored = new Response<IEnumerable<Person>>();
                errored.Data = null;
                errored.Message = e.Message;
                errored.Status = System.Net.HttpStatusCode.InternalServerError;
                return StatusCode(500, errored);
            }
        }
        
        List<Location> adressList = new List<Location>
        {
            new Location("Generaal de witte laan", "Mechelen", "1244", "België", "3"),
            new Location("Generaal de Rode laan", "Mechelen", "4124", "België", "2"),
            new Location("Generaal de Blauwe laan", "Mechelen", "643", "België", "1")
        };

        [HttpGet("{id:guid}/locations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(PersonDto), 200)]
        public IActionResult GetPersonLocations(Guid guid)
        {
            var matchedPerson = people.Find(person => person.PublicId == guid);
            return Ok(GetPersonLocations(guid));
        }
        //
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetId(Guid id)
        {
            var matchedPerson = people.Find(person => person.PublicId == id);
            return Ok(Person.ConvertToDto(matchedPerson));
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            //TODO: persoon ophalen
            //als persoon null is, 404 terggeven
            //als persoon neit null is, verwijderen en 204 teruggeven
            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(PersonDto), 200)]
        public IActionResult Post([FromBody] AddPersonDto person)
        {
            PersonDto newPerson = svc.AddPerson(person);
            people.Add(PersonDto.ConvertToModel(newPerson));
            return CreatedAtAction(nameof(Get), new { id = newPerson.PublicId }, newPerson);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(PersonDto), 200)]
        public IActionResult Put(Guid id, [FromBody] AddPersonDto person) 
        {
            AddPersonDto newPerson = svc.UpdatePerson(id, person);
            return Ok(newPerson);
        }
        
    }
}
