namespace FlowboardAPI.Attendance.Domain.Model.ValueObjects;

//el colaborador necesita tener su código de tarjeta o huella digital representado en un objeto seguro.

public record BiometricId(string Value)
{
    public BiometricId() : this(string.Empty) { }
}