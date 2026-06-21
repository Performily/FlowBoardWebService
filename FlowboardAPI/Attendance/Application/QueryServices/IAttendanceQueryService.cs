using FlowboardAPI.Attendance.Domain.Model.Aggregates;
using FlowboardAPI.Attendance.Domain.Model.Queries;
using FlowboardAPI.Attendance.Interfaces.Rest.Resources;
namespace FlowboardAPI.Attendance.Application.QueryServices;

public interface IAttendanceQueryService
{
    Task<IEnumerable<AttendanceRecord>> Handle(GetAttendanceByEmployeeIdQuery query, CancellationToken cancellationToken);
    Task<AttendanceRecord?> Handle(GetAttendanceByIdQuery query, CancellationToken cancellationToken);
    Task<IEnumerable<AttendanceSummaryResource>> Handle(GetAllAttendanceSummariesQuery query, CancellationToken cancellationToken);
}