using FlowboardAPI.Attendance.Application.CommandServices;
using FlowboardAPI.Attendance.Domain.Model.Aggregates;
using FlowboardAPI.Attendance.Domain.Model.Commands;
using FlowboardAPI.Attendance.Domain.Repositories;
using FlowboardAPI.Shared.Application.Model;
using FlowboardAPI.Shared.Domain.Repositories;

namespace FlowboardAPI.Attendance.Application.Internal.CommandServices;

public class AttendanceCommandService(
    IAttendanceRecordRepository attendanceRepository,
    IUnitOfWork unitOfWork) 
    : IAttendanceCommandService
{
    public async Task<Result<AttendanceRecord>> Handle(CreateAttendanceRecordCommand command, CancellationToken cancellationToken)
    {
        
        var attendanceRecord = new AttendanceRecord(command);

        var horaEntradaOficial = new TimeSpan(9, 0, 0); 
        attendanceRecord.DetermineAttendanceStatus(horaEntradaOficial, toleranceMinutes: 10);

        try
        {
            await attendanceRepository.AddAsync(attendanceRecord, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);

            return Result<AttendanceRecord>.Success(attendanceRecord);
        }
        catch (Exception ex)
        {
            return Result<AttendanceRecord>.Failure(new Error("Attendance.DatabaseError", ex.Message));
        }
    }
}