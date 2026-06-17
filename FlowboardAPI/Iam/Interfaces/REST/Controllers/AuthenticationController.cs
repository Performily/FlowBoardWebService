using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Performily.IAM.Iam.Application.Services;
using Performily.IAM.Iam.Interfaces.REST.Resources;
using Performily.IAM.Iam.Interfaces.REST.Transform;
using Performily.IAM.Iam.Application.Errors;

namespace Performily.IAM.Iam.Interfaces.REST.Controllers;

[ApiController]
[Route("api/v1/auth")]
[SwaggerTag("Autenticación y Manejo de Sesiones (IAM)")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationCommandService _commandService;

    public AuthenticationController(IAuthenticationCommandService commandService)
    {
        _commandService = commandService;
    }

    [HttpPost("sign-in")]
    [SwaggerOperation(Summary = "Iniciar Sesión", Description = "Valida las credenciales del usuario y genera un JWT.")]
    [SwaggerResponse(200, "Operación exitosa", typeof(AuthenticatedUserResource))]
    [SwaggerResponse(401, "Credenciales inválidas")]
    public async Task<IActionResult> SignIn([FromBody] SignInResource resource)
    {
        var command = SignInCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await _commandService.Handle(command);

        return result.Fold<IActionResult>(
            success => {
                var response = AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(success.User, success.Token);
                return Ok(response);
            },
            error => error switch
            {
                AuthenticationError.InvalidCredentials => Unauthorized(new { message = "Correo o contraseña incorrectos" }),
                _ => BadRequest(new { message = "Error inesperado" })
            }
        );
    }
}