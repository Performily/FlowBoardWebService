using FlowboardAPI.Iam.Application.Errors;
using FlowboardAPI.Iam.Domain.Model.Aggregates;
using FlowboardAPI.Iam.Domain.Model.Commands;
using FlowboardAPI.Shared.Application.Patterns;

namespace FlowboardAPI.Iam.Application.Services;

public interface IAuthenticationCommandService
{
    Task<Result<(User User, string Token), AuthenticationError>> Handle(SignInCommand command);
}