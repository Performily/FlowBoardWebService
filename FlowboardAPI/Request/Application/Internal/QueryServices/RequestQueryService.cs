using FlowboardAPI.Requests.Application.QueryServices;
using FlowboardAPI.Requests.Domain.Model.Aggregates;
using FlowboardAPI.Requests.Domain.Model.Queries;
using FlowboardAPI.Requests.Domain.Repositories;

namespace FlowboardAPI.Requests.Application.Internal.QueryServices;

public class RequestQueryService(IRequestRecordRepository requestRepository) : IRequestQueryService
{
    public async Task<RequestRecord?> Handle(GetRequestByIdQuery query, CancellationToken cancellationToken)
    {
        return await requestRepository.FindByIdAsync(query.RequestId);
    }

    public async Task<IEnumerable<RequestRecord>> Handle(GetRequestByEmployeeIdQuery query, CancellationToken cancellationToken)
    {
        return await requestRepository.FindByEmployeeIdAsync(query.EmployeeId);
    }

    public async Task<IEnumerable<RequestRecord>> Handle(GetRequestsByStatusQuery query, CancellationToken cancellationToken)
    {
        return await requestRepository.FindByStatusAsync(query.Status);
    }
}