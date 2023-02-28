using MediatR;
using System.Net;
using TickTick.App.Dtos;
using TickTick.App.Services;

namespace TickTick.App.RequestHandlers.Commands
{
    public class UpdatePersonRequestHandler : IRequestHandler<UpdatePersonRequest, HttpStatusCode>
    {

        private readonly IPersonsService _service;

        public UpdatePersonRequestHandler(IPersonsService service)
        {
            _service = service;
        }

        public async Task<HttpStatusCode> Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
        {
            await _service.UpdatePerson(request.Guid, request.PersonDto);
            return HttpStatusCode.OK;
        }
    }

    public class UpdatePersonRequest : CommandBase<HttpStatusCode>
    {
        public Guid Guid { get; set; }
        public AddPersonDto PersonDto { get; set; }

        public UpdatePersonRequest(AddPersonDto person, Guid id)
        {
            PersonDto = person;
            Guid = id;
        }
    }
}
