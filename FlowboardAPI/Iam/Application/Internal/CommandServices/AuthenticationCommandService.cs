using Performily.IAM.Iam.Application.Errors;
using Performily.IAM.Iam.Application.Services;
using Performily.IAM.Iam.Application.OutboundServices;
using Performily.IAM.Iam.Domain.Model.Aggregates;
using Performily.IAM.Iam.Domain.Model.Commands;
using Performily.IAM.Shared.Application.Patterns;

namespace Performily.IAM.Iam.Application.Internal.CommandServices;

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