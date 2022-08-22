using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Contracts
{
    public interface IAppDbContext
    {
        DbSet<Customer> Customer { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
