using Performily.IAM.Iam.Domain.Model.Commands;
using Performily.IAM.Iam.Domain.Model.ValueObjects;
using Performily.IAM.Iam.Interfaces.REST.Resources;

namespace Performily.IAM.Iam.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(new EmailAddress(resource.Email), resource.Password);
    }
}