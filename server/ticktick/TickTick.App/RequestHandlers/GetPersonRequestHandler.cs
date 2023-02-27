using MediatR;
using TickTick.Models;
using TickTick.Models.Models;
using TickTick.Repositories.Repositories;

namespace TickTick.App.RequestHandlers
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
        private readonly IRepository<Person> _repository;
        public GetPersonRequestHandler(IRepository<Person> repo)
        {
            _repository = repo;
        }

        public async Task<PersonDto> Handle(GetPersonRequest request, CancellationToken cancellationToken)
        {
            var p = await _repository.GetAsync(p => p.PublicId == request.PublicId);
            return PersonExtensions.ConvertToDto(p);
        }
    }
}
