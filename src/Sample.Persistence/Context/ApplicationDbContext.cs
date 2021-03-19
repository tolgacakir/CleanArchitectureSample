using Microsoft.EntityFrameworkCore;
using Sample.Application.Common.Interfaces;
using Sample.Domain.Common;
using Sample.Domain.Entities;
using Sample.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IDateTimeService _dateTimeService;

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions options, IDateTimeService dateTimeService) :base(options)
        {
            _dateTimeService = dateTimeService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration()); //alternative: builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser { DisplayName = "Tolga Çakır", UserName = "tolgacakir", Password = "123", Email = "tolgacakirx@gmail.com", Created = DateTime.Now, CreatedBy = "admin", Id = 1 },
                new AppUser { DisplayName = "USER 2", UserName = "user2", Password = "123", Email = "user2@gmail.com", Created = DateTime.Now, CreatedBy = "admin", Id = 2 });

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity<object>>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "current user"; //TODO: @ApplicationDbContext, get current user id...
                        entry.Entity.Created = _dateTimeService.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = "current user";
                        entry.Entity.LastModified = _dateTimeService.Now;
                        break;
                    default:
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
