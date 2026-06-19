using FlowboardAPI.Iam.Application.CommandServices; // Ajustado a la estructura nueva
using FlowboardAPI.Iam.Application.OutboundServices;
using FlowboardAPI.Iam.Domain.Model.Aggregates;
using FlowboardAPI.Iam.Domain.Model.Commands;
using FlowboardAPI.Iam.Domain.Model.Errors;
using FlowboardAPI.Shared.Application.Model; // El Shared oficial del equipo

namespace FlowboardAPI.Iam.Application.Internal.CommandServices;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly ITokenService _tokenService;

    public AuthenticationCommandService(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    // Retorna el Result<T> del equipo envolviendo la Tupla del usuario y el token
    public async Task<Result<(User User, string Token)>> Handle(SignInCommand command)
    {
        // Limpiamos espacios y minúsculas para asegurar coincidencia perfecta con el Front
        if (command.Email.Value.Trim().ToLower() == "admin@performily.com" && command.Password == "password123")
        {
            var user = new User("Administrador", command.Email, "hashed_password", "RRHH");
            var token = _tokenService.GenerateToken(user);

            // Estilo del equipo: Retorna Success pasando el valor
            return Result<(User User, string Token)>.Success((user, token));
        }

        // Estilo del equipo: Retorna Failure pasando el Enum de error y un mensaje descriptivo
        return Result<(User User, string Token)>.Failure(
            AuthenticationErrors.InvalidCredentials, 
            "Correo o contraseña incorrectos."
        );
    }
}