using FlowboardAPI.Payroll.Domain.Model.Aggregates;
using FlowboardAPI.Payroll.Domain.Model.Queries;

namespace FlowboardAPI.Payroll.Application.QueryServices;

public interface IPaySlipQueryService
{
    Task<IEnumerable<PaySlip>> Handle(GetPaySlipsQuery query, CancellationToken cancellationToken);
    Task<IEnumerable<PaySlip>> Handle(GetPaySlipsByCollaboratorIdQuery query, CancellationToken cancellationToken);
    Task<PaySlip?> Handle(GetPaySlipByIdQuery query, CancellationToken cancellationToken);
}