using FlowboardAPI.Iam.Domain.model.Commands;
using FlowboardAPI.Iam.Domain.model.Aggregates;
using FlowboardAPI.Shared.Application.Model;

namespace FlowboardAPI.Iam.Application.CommandServices;

public interface IAuthenticationCommandService
{
    Task<Result<(User User, string Token)>> Handle(SignInCommand command);
}