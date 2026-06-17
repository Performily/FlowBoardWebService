using FlowboardAPI.Attendance.Domain.Model.Commands;
using FlowboardAPI.Attendance.Domain.Model.ValueObjects;
using FlowboardAPI.Attendance.Interfaces.Rest.Resources;

namespace FlowboardAPI.Attendance.Interfaces.Rest.Transform;

public static class CreateAttendanceRecordCommandFromResourceAssembler
{
    public static CreateAttendanceRecordCommand ToCommandFromResource(CreateAttendanceRecordResource resource)
    {
        return new CreateAttendanceRecordCommand(
            resource.EmployeeId, 
            new BiometricId(resource.BiometricId), 
            resource.Timestamp
        );
    }
}