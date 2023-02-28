using MediatR;
using TickTick.App.Services;
using TickTick.Models;
using TickTick.Models.Models;
using TickTick.Repositories.Repositories;

namespace TickTick.App.RequestHandlers.Querys
{
    public class GetPersonRequest : QueryBase<PersonDto>
    {
        public Guid PublicId { get; set; }
        public GetPersonRequest(Guid publicId)
        {
            PublicId = publicId;
        }
    }
    public class GetPersonRequestHandler : IRequestHandler<GetPersonRequest, PersonDto>
    {
        private readonly IPersonsService _personService;

        public GetPersonRequestHandler(IPersonsService personService)
        {
            _personService = personService;
        }

        public async Task<PersonDto> Handle(GetPersonRequest request, CancellationToken cancellationToken)
        {
            var p = await _personService.GetPerson(request.PublicId);
            return PersonExtensions.ConvertToDto(p);
        }
    }
}
