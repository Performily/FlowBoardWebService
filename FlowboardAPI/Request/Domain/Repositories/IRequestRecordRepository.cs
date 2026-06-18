using FlowboardAPI.Requests.Domain.Model.Aggregates;
using FlowboardAPI.Requests.Domain.Model.ValueObjects;
using FlowboardAPI.Shared.Domain.Repositories;

namespace FlowboardAPI.Requests.Domain.Repositories;

public interface IRequestRecordRepository : IBaseRepository<RequestRecord>
{
    Task<IEnumerable<RequestRecord>> FindByEmployeeIdAsync(int employeeId);
    Task<IEnumerable<RequestRecord>> FindByStatusAsync(ERequestStatus status);
}