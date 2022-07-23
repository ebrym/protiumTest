using Protium.Data.Entity;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace Protium.Data
{
    public class DataContext : DbContext
    {


        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }



        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            int saved = 0;
            // var currentUser = _contextAccessor.HttpContext.User.Identity.Name;
            var currentDate = DateTime.Now;
            try
            {
                foreach (var entry in ChangeTracker.Entries<BaseEntity.Entity>()
               .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.CreatedAt = currentDate;
                    }
                    if (entry.State == EntityState.Modified)
                    {
                        entry.Entity.UpdatedAt = currentDate;
                        //entry.Entity.updated_by = currentUser;

                    }
                }
                saved = await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception Ex)
            {

            }

            return saved;
        }

        public override int SaveChanges()
        {
            int saved = 0;
            // var currentUser = _contextAccessor.HttpContext.User.Identity.Name;
            var currentDate = DateTime.Now;
            try
            {
                foreach (var entry in ChangeTracker.Entries<BaseEntity.Entity>()
               .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.CreatedAt = currentDate;
                    }
                    if (entry.State == EntityState.Modified)
                    {
                        entry.Entity.UpdatedAt = currentDate;
                        //entry.Entity.updated_by = currentUser;

                    }
                }
                saved = base.SaveChanges();
            }
            catch (Exception Ex)
            {

            }

            return saved;
        }

    }

}
  