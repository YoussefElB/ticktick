using System.Data.Entity;
using TickTick.Models;

namespace TickTick.Data
{
    public class TickTickDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistItem> PlaylistItems { get; set; }

    }
}
