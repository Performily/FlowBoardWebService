using FlowboardAPI.Attendance.Domain.Model.Aggregates;
using FlowboardAPI.Attendance.Domain.Repositories;
using FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration; 
using FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories; 
using Microsoft.EntityFrameworkCore;

namespace FlowboardAPI.Attendance.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class AttendanceRecordRepository(AppDbContext context) 
    : BaseRepository<AttendanceRecord>(context), IAttendanceRecordRepository
{
    
    public async Task<IEnumerable<AttendanceRecord>> FindByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken)
    {
        return await Context.Set<AttendanceRecord>()
            .Where(record => record.EmployeeId == employeeId)
            .OrderByDescending(record => record.Timestamp)
            .ToListAsync(cancellationToken);
    }
}