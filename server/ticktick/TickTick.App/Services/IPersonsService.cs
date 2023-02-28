using TickTick.App.Dtos;
using TickTick.Models.Models;

namespace TickTick.App.Services
{
    public interface IPersonsService
    {
        void DeletePerson(Guid id);
        Person AddPerson(AddPersonDto dto);
        Task UpdatePerson(Guid id, AddPersonDto dto);
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person> GetPerson(Guid id);
    }
}