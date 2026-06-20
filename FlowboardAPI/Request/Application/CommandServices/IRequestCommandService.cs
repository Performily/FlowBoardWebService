using FlowboardAPI.Requests.Domain.Model.Aggregates;
using FlowboardAPI.Requests.Domain.Model.Commands;
using FlowboardAPI.Shared.Application.Model;

namespace FlowboardAPI.Requests.Application.CommandServices;

public interface IRequestCommandService
{
    Task<Result<RequestRecord>> Handle(CreateRequestRecordCommand command, CancellationToken cancellationToken);
    Task<Result<RequestRecord>> Handle(ApproveRequestCommand command, CancellationToken cancellationToken);
    Task<Result<RequestRecord>> Handle(RejectRequestCommand command, CancellationToken cancellationToken);
    Task<Result<RequestRecord>> Handle(CancelRequestCommand command, CancellationToken cancellationToken);
}