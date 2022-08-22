using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Contracts
{
    public interface IAppDbContext
    {
        DbSet<Customer> Customer { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
