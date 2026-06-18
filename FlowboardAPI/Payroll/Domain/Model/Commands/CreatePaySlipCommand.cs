namespace FlowboardAPI.Payroll.Domain.Model.Commands;

public record CreatePaySlipCommand(
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