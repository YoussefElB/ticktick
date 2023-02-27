using MediatR;
using Microsoft.AspNetCore.Mvc;
using TickTick.App.Dtos;
using TickTick.App.RequestHandlers;
using TickTick.App.Services;
using TickTick.Models;
using TickTick.Models.Models;
using TickTick.Repositories.Repositories;

namespace TickTick.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ApiControllerBase
    {
        static List<Person> people = new List<Person>();
        private readonly IRepository<Person> repo;
        private readonly IPersonsService svc;
        private readonly IMediator _mediator;

        public PersonsController(IPersonsService personService, IRepository<Person> repo, IMediator mediator) :
            base(mediator)
        {
            svc = personService;
            _mediator = mediator;
            this.repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(PersonDto), 200)]
        public async Task<IActionResult> GetAll()
        {
            return await ExecuteRequest(new GetAllPersonsRequest());
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id)
        {
            return await ExecuteRequest(new GetPersonRequest(id));
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
        public async Task<IActionResult> Post([FromBody] AddPersonDto person)
        {
            return await ExecuteRequest(new AddPersonRequest(person));
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
