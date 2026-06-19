using FlowboardAPI.Iam.Application.QueryServices;
using FlowboardAPI.Iam.Domain.Model.Aggregates;
using FlowboardAPI.Iam.Domain.Model.Queries;
using FlowboardAPI.Iam.Domain.Repositories;

namespace FlowboardAPI.Iam.Application.Internal.QueryServices;

public class UserQueryService : IUserQueryService
{
    private readonly IUserRepository _userRepository;

    // Se inyecta el repositorio que interactúa con el AppDbContext
    public UserQueryService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await _userRepository.FindByIdAsync(query.Id);
    }
}