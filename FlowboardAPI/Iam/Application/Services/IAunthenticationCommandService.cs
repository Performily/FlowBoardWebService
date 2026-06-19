using FlowboardAPI.Iam.Domain.Model.Commands;
using FlowboardAPI.Iam.Domain.Model.Aggregates;
using FlowboardAPI.Shared.Application.Model;

namespace FlowboardAPI.Iam.Application.CommandServices;

public interface IAuthenticationCommandService
{
    Task<Result<(User User, string Token)>> Handle(SignInCommand command);
}