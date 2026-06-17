using FlowboardAPI.Iam.Application.Errors;
using FlowboardAPI.Iam.Application.Services;
using FlowboardAPI.Iam.Application.OutboundServices;
using FlowboardAPI.Iam.Domain.Model.Aggregates;
using FlowboardAPI.Iam.Domain.Model.Commands;
using FlowboardAPI.Shared.Application.Patterns;

namespace FlowboardAPI.Iam.Application.Internal.CommandServices;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly ITokenService _tokenService;
    // Aquí inyectarías tu IUserRepository cuando esté listo de la base de datos

    public AuthenticationCommandService(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    public async Task<Result<(User User, string Token), AuthenticationError>> Handle(SignInCommand command)
    {
        // MOCK TEMPORAL REAL: Validamos las credenciales igual que tu Front
        if (command.Email.Value == "admin@performily.com" && command.Password == "password123")
        {
            // Creamos la instancia de Dominio
            var user = new User("Administrador", command.Email, "hashed_password", "RRHH");
            
            // Generamos el JWT usando la librería de Microsoft
            var token = _tokenService.GenerateToken(user);

            return new Result<(User User, string Token), AuthenticationError>.Success((user, token));
        }

        return new Result<(User User, string Token), AuthenticationError>.Failure(AuthenticationError.InvalidCredentials);
    }
}