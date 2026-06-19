using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using FlowboardAPI.Iam.Application.CommandServices;
using FlowboardAPI.Iam.Interfaces.REST.Resources;
using FlowboardAPI.Iam.Interfaces.REST.Transform;
using FlowboardAPI.Iam.Domain.Model.Errors;
using FlowboardAPI.Iam.Application.QueryServices; 
using FlowboardAPI.Iam.Domain.Model.Queries;     

namespace FlowboardAPI.Iam.Interfaces.REST.Controllers;

[ApiController]
[Route("api/v1/auth")]
[SwaggerTag("Autenticación y Gestión de Identidades (IAM)")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationCommandService _commandService;
    private readonly IUserQueryService _userQueryService;

    public AuthenticationController(IAuthenticationCommandService commandService, IUserQueryService userQueryService)
    {
        _commandService = commandService;
        _userQueryService = userQueryService;
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

    [HttpGet("users/{id:int}")]
    [SwaggerOperation(Summary = "Obtener Usuario por ID", Description = "Recupera el perfil de un usuario específico desde la base de datos.")]
    public async Task<IActionResult> GetUserById([FromRoute] int id)
    {
        var query = new GetUserByIdQuery(id);
        var user = await _userQueryService.Handle(query);

        if (user == null)
        {
            return NotFound(new { message = $"Usuario con ID {id} no fue encontrado." });
        }

        // Mapeas el objeto de dominio a un recurso seguro de salida (Resource)
        // Evitando exponer el PasswordHash en el JSON de respuesta.
        var userResource = new {
            id = user.Id,
            fullName = user.FullName,
            email = user.Email.Value,
            role = user.Role
        };

        return Ok(userResource);
    }
}