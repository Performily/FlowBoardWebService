using FlowboardAPI.Iam.Domain.Model.ValueObjects;

namespace FlowboardAPI.Iam.Domain.Model.Commands;

public record SignInCommand(EmailAddress Email, string Password);
public record ForgotPasswordCommand(EmailAddress Email);
public record ResetPasswordCommand(string Token, string NewPassword);