using TickTick.Data;
using TickTick.Models.Models;

namespace TickTick.Repositories.Repositories
{
    public class PlaylistRepository : Repository<Playlist>
    {

        public PlaylistRepository(TickTickDbContext db) : base(db)
        {
        }
    }
}
