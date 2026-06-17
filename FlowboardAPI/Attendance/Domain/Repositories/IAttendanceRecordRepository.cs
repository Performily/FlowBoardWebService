using FlowboardAPI.Attendance.Domain.Model.Aggregates;
using FlowboardAPI.Shared.Domain.Repositories;

namespace FlowboardAPI.Attendance.Domain.Repositories;

public interface IAttendanceRecordRepository : IBaseRepository<AttendanceRecord>
{
    Task<IEnumerable<AttendanceRecord>> FindByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken);
}