using MediatR;
using System.Net;
using TickTick.App.Dtos;
using TickTick.App.Services;
using TickTick.Models.Models;
using TickTick.Repositories.Repositories;

namespace TickTick.App.RequestHandlers
{
    public class AddPersonRequest : CommandBase<HttpStatusCode>
    {
        public AddPersonDto Person { get; set; }
        public AddPersonRequest(AddPersonDto person)
        {
            Person = person;
        }
    }
    public class AddPersonRequestHandler : IRequestHandler<AddPersonRequest, HttpStatusCode>
    {
        private readonly IPersonsService _service;

        public AddPersonRequestHandler(IPersonsService service)
        {
            _service = service;
        }

        public async Task<HttpStatusCode> Handle(AddPersonRequest request, CancellationToken cancellationToken)
        {
            _service.AddPerson(request.Person);
            return HttpStatusCode.OK;
        }
    }
}
