using FlowboardAPI.Requests.Domain.Model.ValueObjects;

namespace FlowboardAPI.Requests.Domain.Model.Queries;

public record GetRequestsByStatusQuery(ERequestStatus Status);