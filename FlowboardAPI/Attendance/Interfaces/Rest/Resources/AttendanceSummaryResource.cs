namespace FlowboardAPI.Attendance.Interfaces.Rest.Resources;

public record AttendanceSummaryResource(
    int Id,
    int EmployeeId,
    string EmployeeName,
    string Area,
    string Date,
    string CheckIn,
    string CheckOut,
    double WorkedHours,
    string Status
);