namespace FlowboardAPI.Iam.Interfaces.REST.Resources;

public record SignInResource(string Email, string Password);

public record AuthenticatedUserResource(
    int Id, 
    string FullName, 
    string Email, 
    string Role, 
    string Token, 
    bool TemporaryPassword
);