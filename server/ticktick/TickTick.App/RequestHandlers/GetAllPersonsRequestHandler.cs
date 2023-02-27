using MediatR;
using Microsoft.EntityFrameworkCore;
using TickTick.Models;
using TickTick.Models.Models;
using TickTick.Repositories.Repositories;

namespace TickTick.App.RequestHandlers
{
    public class GetAllPersonsRequest : QueryBase<IEnumerable<PersonDto>>
    {
    }
    public class GetAllPersonsRequestHandler : IRequestHandler<GetAllPersonsRequest, IEnumerable<PersonDto>>
    {
        private readonly IRepository<Person> _repository;
        public GetAllPersonsRequestHandler(IRepository<Person> repo)
        {
            this._repository = repo;
        }
        public async Task<IEnumerable<PersonDto>> Handle(GetAllPersonsRequest request, CancellationToken cancellationToken)
        {
            var people =  await _repository.GetAll().ToListAsync();
            var dto = new List<PersonDto>();

            foreach (var person in people)
            {
                dto.Add(PersonExtensions.ConvertToDto(person));
            }
            return dto;
        }
    }
}
