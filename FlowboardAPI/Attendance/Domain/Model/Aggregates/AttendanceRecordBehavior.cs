using FlowboardAPI.Attendance.Domain.Model.ValueObjects;
namespace FlowboardAPI.Attendance.Domain.Model.Aggregates;

public partial class AttendanceRecord
{
    /// <summary>
    /// Evalúa la hora de la marcación contra la hora de entrada oficial para determinar si es tardanza.
    /// </summary>
    /// <param name="officialStartTime">Hora exacta de entrada (ej. 09:00:00)</param>
    /// <param name="toleranceMinutes">Minutos de tolerancia (ej. 10 minutos)</param>
    
    public void DetermineAttendanceStatus(TimeSpan officialStartTime, int toleranceMinutes = 10)
    {
        var arrivalTime = Timestamp.TimeOfDay;
        
       
        var limitTime = officialStartTime.Add(TimeSpan.FromMinutes(toleranceMinutes));

        if (arrivalTime > limitTime)
        {
            Status = EAttendanceStatus.Tardy; 
        }
        else
        {
            Status = EAttendanceStatus.OnTime; 
        }
    }
}