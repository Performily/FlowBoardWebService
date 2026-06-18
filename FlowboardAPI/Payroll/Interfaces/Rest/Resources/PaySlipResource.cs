namespace FlowboardAPI.Payroll.Interfaces.Rest.Resources;

public record PaySlipResource(
    int Id,
    int CollaboratorId,
    string CollaboratorName,
    string CollaboratorCode,
    string Area,
    string Period,
    string PaymentType,
    decimal GrossIncome,
    decimal Deductions,
    decimal NetIncome,
    string Status,
    DateTime IssueDate,
    DateTime? PaymentDate);