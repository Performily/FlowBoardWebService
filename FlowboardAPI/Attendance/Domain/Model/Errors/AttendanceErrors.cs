using FlowboardAPI.Shared.Domain.Model;

namespace FlowboardAPI.Attendance.Domain.Model.Errors;

public static class AttendanceErrors
{
    public static readonly Error AttendanceRecordNotFound =
        new("Attendance.AttendanceRecordNotFound", "The specified attendance record was not found.");

    public static readonly Error EmployeeNotFound =
        new("Attendance.EmployeeNotFound", "The specified employee was not found.");
}