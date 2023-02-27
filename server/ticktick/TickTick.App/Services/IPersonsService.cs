using TickTick.App.Dtos;
using TickTick.Models.Models;

namespace TickTick.App.Services
{
    public interface IPersonsService
    {
        void DeletePerson(Guid id);
        Person AddPerson(AddPersonDto dto);
        AddPersonDto UpdatePerson(Guid id, AddPersonDto dto);
    }
}