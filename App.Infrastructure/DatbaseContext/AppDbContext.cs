using App.Core.Contracts;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace App.Infrastructure.DatbaseContext
{
    public class AppDbContext : DbContext, IAppDbContext
    {
       private readonly IDateTimeService _dateTime; 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
         
        }
        public AppDbContext(DbContextOptions<AppDbContext> options, IDateTimeService dateTime) :base(options)
        {
            _dateTime = dateTime;
        }
        public DbSet<Customer> Customer { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity &&
             (e.State == EntityState.Added || e.State == EntityState.Modified)).Select(x => x.Entity as BaseEntity);

            await UpdateEntries(entries, _dateTime.Now);

            return await base.SaveChangesAsync(cancellationToken);
        }
       
        protected virtual async Task UpdateEntries(IEnumerable<BaseEntity> entries, DateTime savedTime)
        {
            /*
             * This username will be coming from current user loggedin
             * Create a service that will hold the current user
             */
            const string username = "system";

            foreach (var entry in entries)
            {
                if (entry.Id == default || string.IsNullOrEmpty(entry.CreatedBy))
                {
                    entry.CreatedOn = _dateTime.Now;
                    entry.CreatedBy = username;
                }
                entry.LastModified = _dateTime.Now;
                entry.LastModifiedBy = username;
            }

        }


    }
}
