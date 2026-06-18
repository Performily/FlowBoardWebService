using FlowboardAPI.Payroll.Domain.Model.Aggregates;
using FlowboardAPI.Payroll.Domain.Model.Commands;
using FlowboardAPI.Shared.Application.Model;

namespace FlowboardAPI.Payroll.Application.CommandServices;

public interface IPaySlipCommandService
{
    Task<Result<PaySlip>> Handle(CreatePaySlipCommand command, CancellationToken cancellationToken);
    Task<Result<PaySlip>> Handle(UpdatePaySlipStatusCommand command, CancellationToken cancellationToken);
}