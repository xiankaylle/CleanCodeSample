using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Contracts
{
    public interface IAppDbContext : IDbContext
    {
        DbSet<Customer> Customer { get; set; }
    }
}
