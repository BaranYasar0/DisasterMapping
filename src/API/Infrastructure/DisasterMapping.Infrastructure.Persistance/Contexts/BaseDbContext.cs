using DisasterMapping.Api.Domain.Entities;
using DisasterMapping.Api.Domain.Entities.Common;
using DisasterMapping.Infrastructure.Persistance.DataSeeding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DisasterMapping.Infrastructure.Persistance.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected BaseDbContext()
        {
        }
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<City>().HasData(BaseContextDataSeeding.GetCities());

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            GenerateDateTime();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            GenerateDateTime();
            return base.SaveChangesAsync(cancellationToken);
        }

        public void GenerateDateTime()
        {
            var entities = ChangeTracker.Entries<BaseEntity>();

            foreach (var entity in entities)
            {
                _ = entity.State switch
                {
                    EntityState.Added=> entity.Entity.CreatedDate= DateTime.Now,
                    EntityState.Modified => entity.Entity.UpdatedDate = DateTime.Now,
                    _ =>DateTime.Now

                };
            }
        }
    }
}
