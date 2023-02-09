using TickTick.Models;

namespace TickTick.App.Services
{
    public interface IPersonsService
    {
        void DeletePerson(Guid id);
        PersonDto AddPerson(AddPersonDto dto);
        AddPersonDto UpdatePerson(Guid id, AddPersonDto dto);
    }
}