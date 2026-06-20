using FlowboardAPI.Requests.Application.CommandServices;
using FlowboardAPI.Requests.Domain.Model.Aggregates;
using FlowboardAPI.Requests.Domain.Model.Commands;
using FlowboardAPI.Requests.Domain.Repositories;
using FlowboardAPI.Shared.Application.Model;
using FlowboardAPI.Shared.Domain.Repositories;

namespace FlowboardAPI.Requests.Application.Internal.CommandServices;

public class RequestCommandService(
    IRequestRecordRepository requestRepository,
    IUnitOfWork unitOfWork) 
    : IRequestCommandService
{
    public async Task<Result<RequestRecord>> Handle(CreateRequestRecordCommand command, CancellationToken cancellationToken)
    {
        var requestRecord = new RequestRecord(command);

        try
        {
            await requestRepository.AddAsync(requestRecord, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);
            return Result<RequestRecord>.Success(requestRecord);
        }
        catch (Exception ex)
        {
            return Result<RequestRecord>.Failure((Enum)null!, ex.Message);
        }
    }

    public async Task<Result<RequestRecord>> Handle(ApproveRequestCommand command, CancellationToken cancellationToken)
    {
        var requestRecord = await requestRepository.FindByIdAsync(command.RequestId);
        if (requestRecord == null) 
            return Result<RequestRecord>.Failure((Enum)null!, "Solicitud no encontrada.");

        try
        {
            requestRecord.Approve(command.ReviewerId);
            requestRepository.Update(requestRecord);
            await unitOfWork.CompleteAsync(cancellationToken);
            return Result<RequestRecord>.Success(requestRecord);
        }
        catch (Exception ex)
        {
            return Result<RequestRecord>.Failure((Enum)null!, ex.Message);
        }
    }

    public async Task<Result<RequestRecord>> Handle(RejectRequestCommand command, CancellationToken cancellationToken)
    {
        var requestRecord = await requestRepository.FindByIdAsync(command.RequestId);
        if (requestRecord == null) 
            return Result<RequestRecord>.Failure((Enum)null!, "Solicitud no encontrada.");

        try
        {
            requestRecord.Reject(command.ReviewerId, command.Reason);
            requestRepository.Update(requestRecord);
            await unitOfWork.CompleteAsync(cancellationToken);
            return Result<RequestRecord>.Success(requestRecord);
        }
        catch (Exception ex)
        {
            return Result<RequestRecord>.Failure((Enum)null!, ex.Message);
        }
    }

    public async Task<Result<RequestRecord>> Handle(CancelRequestCommand command, CancellationToken cancellationToken)
    {
        var requestRecord = await requestRepository.FindByIdAsync(command.RequestId);
        if (requestRecord == null) 
            return Result<RequestRecord>.Failure((Enum)null!, "Solicitud no encontrada.");

        try
        {
            requestRecord.Cancel();
            requestRepository.Update(requestRecord);
            await unitOfWork.CompleteAsync(cancellationToken);
            return Result<RequestRecord>.Success(requestRecord);
        }
        catch (Exception ex)
        {
            return Result<RequestRecord>.Failure((Enum)null!, ex.Message);
        }
    }
}