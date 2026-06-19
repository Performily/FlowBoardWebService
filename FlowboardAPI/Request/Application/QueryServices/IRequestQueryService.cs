using FlowboardAPI.Requests.Domain.Model.Aggregates;
using FlowboardAPI.Requests.Domain.Model.Queries;

namespace FlowboardAPI.Requests.Application.QueryServices;

public interface IRequestQueryService
{
    Task<RequestRecord?> Handle(GetRequestByIdQuery query, CancellationToken cancellationToken);
    Task<IEnumerable<RequestRecord>> Handle(GetRequestByEmployeeIdQuery query, CancellationToken cancellationToken);
    Task<IEnumerable<RequestRecord>> Handle(GetRequestsByStatusQuery query, CancellationToken cancellationToken);
}