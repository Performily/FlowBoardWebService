using FlowboardAPI.Attendance.Domain.Model.Aggregates;
using FlowboardAPI.Attendance.Domain.Model.Commands;
using FlowboardAPI.Shared.Application.Model; 

namespace FlowboardAPI.Attendance.Application.CommandServices;

public interface IAttendanceCommandService
{
    Task<Result<AttendanceRecord>> Handle(CreateAttendanceRecordCommand command, CancellationToken cancellationToken);
}