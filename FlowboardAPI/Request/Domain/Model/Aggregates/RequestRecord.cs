using FlowboardAPI.Requests.Domain.Model.Commands;
using FlowboardAPI.Requests.Domain.Model.ValueObjects;

namespace FlowboardAPI.Requests.Domain.Model.Aggregates;

public partial class RequestRecord
{
    protected RequestRecord()
    {
        Justification = null!;
        Period = null!;
        TimeFrame = null!;
        Evidence = null!;
        ReviewDetails = new ReviewDetails();
    }

    public RequestRecord(CreateRequestRecordCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        EmployeeId = command.EmployeeId;
        Type = command.Type;
        Status = ERequestStatus.Pending; 
        CreatedAt = DateTime.UtcNow;
        
        Justification = command.Justification;
        Period = command.Period;
        TimeFrame = command.TimeFrame;
        Evidence = command.Evidence;
        ReviewDetails = new ReviewDetails();
    }

    public int Id { get; private set; }
    public int EmployeeId { get; private set; }
    public ERequestType Type { get; private set; }
    public ERequestStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    public Justification Justification { get; private set; }
    public RequestPeriod Period { get; private set; }
    public RequestTimeFrame TimeFrame { get; private set; }
    public Evidence Evidence { get; private set; }
    public ReviewDetails ReviewDetails { get; private set; }
}