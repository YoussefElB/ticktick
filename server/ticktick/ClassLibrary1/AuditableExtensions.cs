using Microsoft.EntityFrameworkCore;
using TickTick.Models;

namespace TickTick.Data
{
    public static class AuditableExtensions
    {
        public static void AddAuditableInfo(this DbContext context)
        {
            //PUT, POST, & Delete
            //baseAuditableEntity

            var entries = context.ChangeTracker.Entries<BaseAuditableEntity>().Where(e => e.Entity is BaseAuditableEntity 
            && (e.State == EntityState.Added || e.State == EntityState.Modified));
            foreach ( var entry in entries)
            {
                if (entry.State is EntityState.Added) entry.Entity.CreatedAt = DateTime.UtcNow;
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}
