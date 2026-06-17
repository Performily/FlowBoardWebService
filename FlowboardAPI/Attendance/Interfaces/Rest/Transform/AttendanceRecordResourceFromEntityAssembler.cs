using FlowboardAPI.Attendance.Domain.Model.Aggregates;
using FlowboardAPI.Attendance.Interfaces.Rest.Resources;

namespace FlowboardAPI.Attendance.Interfaces.Rest.Transform;

public static class AttendanceRecordResourceFromEntityAssembler
{
    public static AttendanceRecordResource ToResourceFromEntity(AttendanceRecord entity)
    {
        return new AttendanceRecordResource(
            entity.Id,
            entity.EmployeeId,
            entity.BiometricId.Value, 
            entity.Timestamp,
            entity.Status.ToString() 
        );
    }
}