using System.Runtime.CompilerServices;
using TickTick.Models.Models;
using TickTick.Repositories.Repositories;

namespace TickTick.Repositories
{
    public class PersonRepositoryExtensions
    {
        private IEnumerable<Person> GetDeadPeople(Repository<Person> repo)
        {
            return repo.GetAll();
        }
    }
}
