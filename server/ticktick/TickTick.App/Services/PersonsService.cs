using TickTick.App.Dtos;
using TickTick.Models;

namespace TickTick.App.Services
{
    public class PersonsService : IPersonsService
    {
        public Person AddPerson(AddPersonDto dto)
        {
            Person person = new Person(
                dto.FirstName,
                dto.LastName,
                dto.Email);

            person.CreatePublicId();
            return person;
        }

        public AddPersonDto UpdatePerson(Guid id, AddPersonDto persondto)
        {
            //no clue yet, no repo
            return persondto;
        }

        public void DeletePerson(Guid id)
        {
            //TODO: create delete method i suppose
        }

    }
}
