using FlowboardAPI.Payroll.Domain.Model.Aggregates;
using FlowboardAPI.Shared.Domain.Repositories;

namespace FlowboardAPI.Payroll.Domain.Repositories;

public interface IPaySlipRepository : IBaseRepository<PaySlip>
{
    Task<IEnumerable<PaySlip>> ListAsync(string? period, string? status, string? search, CancellationToken cancellationToken);
    Task<IEnumerable<PaySlip>> FindByCollaboratorIdAsync(int collaboratorId, CancellationToken cancellationToken);
}