namespace FlowboardAPI.Workspace.Domain.Model.ValueObjects;

public record DocumentNumber
{
    public string Number { get; init; }

    public DocumentNumber(string number)
    {
        if (string.IsNullOrWhiteSpace(number) || number.Length < 8)
            throw new ArgumentException("Número de documento inválido");
            
        Number = number;
    }
}