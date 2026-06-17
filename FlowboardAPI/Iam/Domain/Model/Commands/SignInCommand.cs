using Performily.IAM.Iam.Domain.Model.ValueObjects;

namespace Performily.IAM.Iam.Domain.Model.Commands;

public record SignInCommand(EmailAddress Email, string Password);
public record ForgotPasswordCommand(EmailAddress Email);
public record ResetPasswordCommand(string Token, string NewPassword);