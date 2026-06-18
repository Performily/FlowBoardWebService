using FlowboardAPI.Payroll.Application.CommandServices;
using FlowboardAPI.Payroll.Domain.Model.Aggregates;
using FlowboardAPI.Payroll.Domain.Model.Commands;
using FlowboardAPI.Payroll.Domain.Model.Errors;
using FlowboardAPI.Payroll.Domain.Repositories;
using FlowboardAPI.Shared.Application.Model;
using FlowboardAPI.Shared.Domain.Repositories;

namespace FlowboardAPI.Payroll.Application.Internal.CommandServices;

public class PaySlipCommandService(
    IPaySlipRepository paySlipRepository,
    IUnitOfWork unitOfWork)
    : IPaySlipCommandService
{
    public async Task<Result<PaySlip>> Handle(CreatePaySlipCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var paySlip = new PaySlip(command);

            await paySlipRepository.AddAsync(paySlip, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);

            return Result<PaySlip>.Success(paySlip);
        }
        catch (Exception ex)
        {
            return Result<PaySlip>.Failure(PayrollErrors.PaySlipCouldNotBeCreated, ex.Message);
        }
    }

    public async Task<Result<PaySlip>> Handle(UpdatePaySlipStatusCommand command, CancellationToken cancellationToken)
    {
        var paySlip = await paySlipRepository.FindByIdAsync(command.PaySlipId, cancellationToken);

        if (paySlip is null)
            return Result<PaySlip>.Failure(PayrollErrors.PaySlipNotFound, "Pay slip not found.");

        try
        {
            paySlip.UpdateStatusFromText(command.Status);
            paySlipRepository.Update(paySlip);
            await unitOfWork.CompleteAsync(cancellationToken);

            return Result<PaySlip>.Success(paySlip);
        }
        catch (ArgumentException ex)
        {
            return Result<PaySlip>.Failure(PayrollErrors.InvalidPaySlipStatus, ex.Message);
        }
        catch (Exception ex)
        {
            return Result<PaySlip>.Failure(PayrollErrors.PaySlipCouldNotBeUpdated, ex.Message);
        }
    }
}
