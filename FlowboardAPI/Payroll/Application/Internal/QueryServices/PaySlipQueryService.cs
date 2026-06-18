using FlowboardAPI.Payroll.Application.QueryServices;
using FlowboardAPI.Payroll.Domain.Model.Aggregates;
using FlowboardAPI.Payroll.Domain.Model.Queries;
using FlowboardAPI.Payroll.Domain.Repositories;

namespace FlowboardAPI.Payroll.Application.Internal.QueryServices;

public class PaySlipQueryService(IPaySlipRepository paySlipRepository)
    : IPaySlipQueryService
{
    public async Task<IEnumerable<PaySlip>> Handle(GetPaySlipsQuery query, CancellationToken cancellationToken)
    {
        return await paySlipRepository.ListAsync(query.Period, query.Status, query.Search, cancellationToken);
    }

    public async Task<IEnumerable<PaySlip>> Handle(GetPaySlipsByCollaboratorIdQuery query, CancellationToken cancellationToken)
    {
        return await paySlipRepository.FindByCollaboratorIdAsync(query.CollaboratorId, cancellationToken);
    }

    public async Task<PaySlip?> Handle(GetPaySlipByIdQuery query, CancellationToken cancellationToken)
    {
        return await paySlipRepository.FindByIdAsync(query.PaySlipId, cancellationToken);
    }
}