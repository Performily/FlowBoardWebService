using FlowboardAPI.Attendance.Application.QueryServices;
using FlowboardAPI.Attendance.Domain.Model.Aggregates;
using FlowboardAPI.Attendance.Domain.Model.Queries;
using FlowboardAPI.Attendance.Domain.Repositories;
using FlowboardAPI.Attendance.Interfaces.Rest.Resources; 

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

    public async Task<IEnumerable<AttendanceSummaryResource>> Handle(GetAllAttendanceSummariesQuery query, CancellationToken cancellationToken)
    {
        var records = await attendanceRepository.ListAsync();

        var summaries = records
            .GroupBy(r => new { r.EmployeeId, Date = r.Timestamp.Date })
            .Select(g => {
                var checkInTime = g.Min(r => r.Timestamp);
                var checkOutTime = g.Max(r => r.Timestamp);
                
                var workedHours = (checkOutTime - checkInTime).TotalHours;

                return new AttendanceSummaryResource(
                    Id: g.First().Id, 
                    EmployeeId: g.Key.EmployeeId,
                    EmployeeName: $"Empleado #{g.Key.EmployeeId}", 
                    Area: "Sistemas", 
                    Date: g.Key.Date.ToString("yyyy-MM-dd"),
                    CheckIn: checkInTime.ToString("HH:mm"),
                    CheckOut: checkOutTime == checkInTime ? "--:--" : checkOutTime.ToString("HH:mm"),
                    WorkedHours: Math.Round(workedHours, 2),
                    Status: "Asistencia"
                );
            }).ToList();

        return summaries;
    }
}