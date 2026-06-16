using FlowboardAPI.Shared.Domain.Model;
namespace FlowboardAPI.Attendance.Domain.Model.Aggregates;

public partial class AttendanceRecord : IAuditableEntity
{
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}