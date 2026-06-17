namespace FlowboardAPI.Attendance.Domain.Model.ValueObjects;

//archivo para definir qué estados de marcación reconoce el sistema
public enum EAttendanceStatus
{
    OnTime,
    Tardy,
    Absent,
    Justified
}