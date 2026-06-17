using Performily.IAM.Iam.Application.Errors;
using Performily.IAM.Iam.Domain.Model.Aggregates;
using Performily.IAM.Iam.Domain.Model.Commands;
using Performily.IAM.Shared.Application.Patterns;

namespace Performily.IAM.Iam.Application.Services;

public interface IAuthenticationCommandService
{
    Task<Result<(User User, string Token), AuthenticationError>> Handle(SignInCommand command);
}