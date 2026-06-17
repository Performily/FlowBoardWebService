using FlowboardAPI.Attendance.Domain.Model.Commands;
using FlowboardAPI.Attendance.Domain.Model.ValueObjects;

namespace FlowboardAPI.Attendance.Domain.Model.Aggregates;

public partial class AttendanceRecord
{
    protected AttendanceRecord()
    {
        BiometricId = null!;
    }
    
    public AttendanceRecord(CreateAttendanceRecordCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        EmployeeId = command.EmployeeId;
        BiometricId = command.BiometricId;
        Timestamp = command.Timestamp;
        Status = EAttendanceStatus.OnTime; 
    }
    
    public int Id { get; private set; }
    public int EmployeeId { get; private set; } 
    public BiometricId BiometricId { get; private set; } 
    public DateTime Timestamp { get; private set; }
    public EAttendanceStatus Status { get; private set; }
}