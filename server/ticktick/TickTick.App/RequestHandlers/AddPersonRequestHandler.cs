using MediatR;
using System.Net;
using TickTick.App.Dtos;
using TickTick.Models.Models;
using TickTick.Repositories.Repositories;

namespace TickTick.App.RequestHandlers
{
    public class AddPersonRequest : QueryBase<HttpStatusCode>
    {
        public AddPersonDto Person { get; set; }
        public AddPersonRequest(AddPersonDto person)
        {
            Person = person;
        }
    }
    public class AddPersonRequestHandler : IRequestHandler<AddPersonRequest, HttpStatusCode>
    {
        private readonly IRepository<Person> _repository;

        public AddPersonRequestHandler(IRepository<Person> repo)
        {
            this._repository = repo;
        }
        public async Task<HttpStatusCode> Handle(AddPersonRequest request, CancellationToken cancellationToken)
        {
            var somethingThatsUhhhConverted = AddPersonDto.ConvertToModel(request.Person);
            _repository.Add(somethingThatsUhhhConverted);
            return HttpStatusCode.OK;
        }
    }
}
