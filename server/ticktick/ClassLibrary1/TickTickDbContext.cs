using Microsoft.EntityFrameworkCore;
using TickTick.Models.Models;

namespace TickTick.Data
{
    public class TickTickDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistItem> PlaylistItems { get; set; }

        public TickTickDbContext(DbContextOptions options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.AddAuditableInfo();
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
