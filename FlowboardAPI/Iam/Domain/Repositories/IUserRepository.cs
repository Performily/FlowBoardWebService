using FlowboardAPI.Iam.Domain.Model.Aggregates;

namespace FlowboardAPI.Iam.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> FindByIdAsync(int id);
    // Nota: Como ya heredan del Shared/IBaseRepository si su arquitectura lo incluye, 
    // puedes dejarlo explícito aquí para asegurar la lectura simple.
}