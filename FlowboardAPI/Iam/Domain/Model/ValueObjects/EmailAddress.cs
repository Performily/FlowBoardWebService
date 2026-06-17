namespace FlowboardAPI.Iam.Domain.model.ValueObjects;
public record EmailAddress
{
    public string Value { get; }

    public EmailAddress(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
            throw new ArgumentException("Formato de correo electrónico inválido.");
        Value = value;
    }
}