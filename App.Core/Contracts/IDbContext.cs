
namespace App.Core.Contracts
{
    public interface IDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
