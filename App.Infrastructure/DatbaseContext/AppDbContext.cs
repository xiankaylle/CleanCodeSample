using App.Core.Contracts;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace App.Infrastructure.DatbaseContext
{
    public class AppDbContext : DbContext, IAppDbContext
    {
       
        public AppDbContext(DbContextOptions options) :base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }

       
    }
}
