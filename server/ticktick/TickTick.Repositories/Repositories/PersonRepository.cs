using TickTick.Data;
using TickTick.Models.Models;

namespace TickTick.Repositories.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(TickTickDbContext db) : base(db)
        {
        }
    }
}
