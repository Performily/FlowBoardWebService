using Performily.IAM.Iam.Domain.Model.Aggregates;
using Performily.IAM.Iam.Interfaces.REST.Resources;

namespace Performily.IAM.Iam.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User user, string token)
    {
        return new AuthenticatedUserResource(
            user.Id,
            user.FullName,
            user.Email.Value,
            user.Role,
            token,
            user.TemporaryPassword
        );
    }
}