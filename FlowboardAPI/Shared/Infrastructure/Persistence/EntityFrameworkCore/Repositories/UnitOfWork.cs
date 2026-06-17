using FlowboardAPI.Shared.Domain.Repositories;
using FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;

namespace FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}