using TickTick.App.Dtos;
using TickTick.Models.Models;
using TickTick.Repositories.Repositories;

namespace TickTick.App.Services
{
    public class PersonsService : IPersonsService
    {
        private readonly IPersonRepository _personRepository;

        public PersonsService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public Person AddPerson(AddPersonDto dto)
        {
            Person person = new Person(
                dto.FirstName,
                dto.LastName,
                dto.Email);

            person.CreatePublicId();
            _personRepository.Add(person);

            return person;
        }

        public void DeletePerson(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _personRepository.GetAllAsync();
        }

        public async Task<Person> GetPerson(Guid id)
        {
            return await _personRepository.GetAsync(p => p.PublicId == id);
        }

        public async Task UpdatePerson(Guid id, AddPersonDto dto)
        {
            var person = await GetPerson(id);
            person.FirstName = dto.FirstName; 
            person.LastName = dto.LastName;
            person.MiddleName = dto.MiddleName;
            person.DateOfBirth = dto.DateOfBirth;
            person.DateOfDeath = dto.DateOfDeath;
            person.Email = dto.Email;
            await _personRepository.Update(person);
        }
    }
}
