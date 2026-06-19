namespace FlowboardAPI.Iam.Domain.Model.Queries;

// Las queries en CQRS son inmutables y solo transportan los parámetros de búsqueda
public record GetUserByIdQuery(int Id);