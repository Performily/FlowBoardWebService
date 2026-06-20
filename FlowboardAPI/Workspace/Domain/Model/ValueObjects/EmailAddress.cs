namespace FlowboardAPI.Workspace.Domain.Model.ValueObjects;

public record EmailAddress
{
    public string Address { get; init; }

    public EmailAddress(string address)
    {
        if (string.IsNullOrWhiteSpace(address) || !address.Contains("@"))
            throw new ArgumentException("Formato de correo electrónico inválido");
            
        Address = address;
    }
}