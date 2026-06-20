using FlowboardAPI.Requests.Domain.Model.ValueObjects;

namespace FlowboardAPI.Requests.Domain.Model.Commands;

public record CreateRequestRecordCommand(
    int EmployeeId,
    ERequestType Type,
    Justification Justification,
    RequestPeriod Period,
    RequestTimeFrame TimeFrame,
    Evidence Evidence);