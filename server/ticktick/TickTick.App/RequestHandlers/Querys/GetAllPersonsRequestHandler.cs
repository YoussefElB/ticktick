using MediatR;
using Microsoft.EntityFrameworkCore;
using TickTick.App.Services;
using TickTick.Models;
using TickTick.Models.Models;
using TickTick.Repositories.Repositories;

namespace TickTick.App.RequestHandlers.Querys
{
    public class GetAllPersonsRequest : QueryBase<IEnumerable<PersonDto>>
    {
    }
    public class GetAllPersonsRequestHandler : IRequestHandler<GetAllPersonsRequest, IEnumerable<PersonDto>>
    {
        private readonly IPersonsService personsService;
        public GetAllPersonsRequestHandler(IPersonsService repo)
        {
            personsService = repo;
        }
        public async Task<IEnumerable<PersonDto>> Handle(GetAllPersonsRequest request, CancellationToken cancellationToken)
        {
            var people = await personsService.GetAllAsync();
            var dto = new List<PersonDto>();

            foreach (var person in people)
            {
                dto.Add(PersonExtensions.ConvertToDto(person));
            }
            return dto;
        }
    }
}
