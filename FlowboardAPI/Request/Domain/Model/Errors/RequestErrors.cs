namespace FlowboardAPI.Requests.Domain.Model.Errors;

public static class RequestErrors
{
    public const string NotFound = "La solicitud no fue encontrada.";
    public const string InvalidStateTransition = "La transición de estado no es válida para esta solicitud.";
    public const string ReasonRequired = "Se requiere un motivo detallado para rechazar la solicitud.";
}