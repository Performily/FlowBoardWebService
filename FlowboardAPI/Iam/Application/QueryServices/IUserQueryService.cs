using FlowboardAPI.Iam.Domain.Model.Aggregates;
using FlowboardAPI.Iam.Domain.Model.Queries;

namespace FlowboardAPI.Iam.Application.QueryServices;

public interface IUserQueryService
{
    // Retorna el usuario o null si no existe en MySQL
    Task<User?> Handle(GetUserByIdQuery query);
}