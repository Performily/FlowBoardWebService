using FlowboardAPI.Attendance.Domain.Model.ValueObjects;
namespace FlowboardAPI.Attendance.Domain.Model.Commands;

public record CreateAttendanceRecordCommand(int EmployeeId, BiometricId BiometricId, DateTime Timestamp);