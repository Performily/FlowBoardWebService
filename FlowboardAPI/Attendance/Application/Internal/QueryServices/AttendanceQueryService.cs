using FlowboardAPI.Attendance.Application.QueryServices;
using FlowboardAPI.Attendance.Domain.Model.Aggregates;
using FlowboardAPI.Attendance.Domain.Model.Queries;
using FlowboardAPI.Attendance.Domain.Repositories;

namespace FlowboardAPI.Attendance.Application.Internal.QueryServices;

public class AttendanceQueryService(IAttendanceRecordRepository attendanceRepository) 
    : IAttendanceQueryService
{
  
    public async Task<IEnumerable<AttendanceRecord>> Handle(GetAttendanceByEmployeeIdQuery query, CancellationToken cancellationToken)
    {
        return await attendanceRepository.FindByEmployeeIdAsync(query.EmployeeId, cancellationToken);
    }

    public async Task<AttendanceRecord?> Handle(GetAttendanceByIdQuery query, CancellationToken cancellationToken)
    {
        return await attendanceRepository.FindByIdAsync(query.AttendanceRecordId, cancellationToken);
    }
}