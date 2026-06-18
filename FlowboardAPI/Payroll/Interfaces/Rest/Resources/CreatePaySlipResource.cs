namespace FlowboardAPI.Payroll.Interfaces.Rest.Resources;

public record CreatePaySlipResource(
    int CollaboratorId,
    string CollaboratorName,
    string CollaboratorCode,
    string Area,
    string Period,
    string PaymentType,
    decimal GrossIncome,
    decimal Deductions,
    DateTime IssueDate,
    DateTime? PaymentDate,
    string? PdfFileName);