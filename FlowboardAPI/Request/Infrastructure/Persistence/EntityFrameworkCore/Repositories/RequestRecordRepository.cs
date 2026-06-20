using FlowboardAPI.Requests.Domain.Model.Aggregates;
using FlowboardAPI.Requests.Domain.Model.ValueObjects;
using FlowboardAPI.Requests.Domain.Repositories;
using FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration; 
using FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlowboardAPI.Requests.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class RequestRecordRepository(AppDbContext dbContext) 
    : BaseRepository<RequestRecord>(dbContext), IRequestRecordRepository
{
    public async Task<IEnumerable<RequestRecord>> FindByEmployeeIdAsync(int employeeId)
    {
        return await Context.Set<RequestRecord>()
            .Where(r => r.EmployeeId == employeeId)
            .ToListAsync();
    }

    public async Task<IEnumerable<RequestRecord>> FindByStatusAsync(ERequestStatus status)
    {
        return await Context.Set<RequestRecord>()
            .Where(r => r.Status == status)
            .ToListAsync();
    }
}