using FlowboardAPI.Iam.Domain.Model.Commands;
using FlowboardAPI.Iam.Domain.Model.ValueObjects;
using FlowboardAPI.Iam.Interfaces.REST.Resources;

namespace FlowboardAPI.Iam.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(new EmailAddress(resource.Email), resource.Password);
    }
}