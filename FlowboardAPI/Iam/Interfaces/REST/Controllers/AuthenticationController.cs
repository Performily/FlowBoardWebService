using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using FlowboardAPI.Iam.Application.CommandServices;
using FlowboardAPI.Iam.Interfaces.REST.Resources;
using FlowboardAPI.Iam.Interfaces.REST.Transform;
using FlowboardAPI.Iam.Domain.Model.Errors;

namespace FlowboardAPI.Iam.Interfaces.REST.Controllers;

[ApiController]
[Route("api/v1/auth")]
[SwaggerTag("Autenticación y Gestión de Identidades (IAM)")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationCommandService _commandService;

    public AuthenticationController(IAuthenticationCommandService commandService)
    {
        _commandService = commandService;
    }

    [HttpPost("sign-in")]
    [SwaggerOperation(Summary = "Iniciar Sesión", Description = "Autentica al usuario usando el estándar oficial de la plataforma.")]
    public async Task<IActionResult> SignIn([FromBody] SignInResource resource)
    {
        var command = SignInCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await _commandService.Handle(command);

        // Evaluamos usando las propiedades del Result<T> de la carpeta Shared del equipo
        if (result.IsSuccess)
        {
            // result.Value contiene nuestra tupla (User, Token)
            var response = AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(
                result.Value.User, 
                result.Value.Token
            );
            return Ok(response);
        }

        // Si falló, mapeamos según el tipo de Error almacenado en el Result
        return result.Error switch
        {
            AuthenticationErrors.InvalidCredentials => Unauthorized(new { message = result.Message }),
            _ => BadRequest(new { message = "Error interno en el proceso de autenticación." })
        };
    }
}