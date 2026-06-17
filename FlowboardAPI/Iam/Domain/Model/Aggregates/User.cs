using Performily.IAM.Iam.Domain.Model.ValueObjects;

namespace Performily.IAM.Iam.Domain.Model.Aggregates;

public class User
{
    public int Id { get; private set; }
    public string FullName { get; private set; }
    public EmailAddress Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string Role { get; private set; } // "RRHH" o "Colaborador"
    public bool TemporaryPassword { get; private set; }

    protected User() {} // Requerido por EF Core

    public User(string fullName, EmailAddress email, string passwordHash, string role)
    {
        FullName = fullName;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
        TemporaryPassword = false;
    }
}