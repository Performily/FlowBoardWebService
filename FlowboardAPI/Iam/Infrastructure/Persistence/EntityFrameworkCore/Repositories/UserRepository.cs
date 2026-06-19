using FlowboardAPI.Iam.Domain.Model.Aggregates;
using FlowboardAPI.Iam.Domain.Repositories;
using FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FlowboardAPI.Iam.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    // Inyectamos el DbContext unificado del Shared que ya mapea tu tabla 'users'
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    // Buscamos el usuario en MySQL por su ID
    public async Task<User?> FindByIdAsync(int id)
    {
        return await _context.Set<User>()
            .FirstOrDefaultAsync(user => user.Id == id);
    }
}