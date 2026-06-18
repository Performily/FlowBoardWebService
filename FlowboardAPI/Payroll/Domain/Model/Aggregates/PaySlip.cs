using FlowboardAPI.Payroll.Domain.Model.Commands;
using FlowboardAPI.Payroll.Domain.Model.ValueObjects;

namespace FlowboardAPI.Payroll.Domain.Model.Aggregates;

public partial class PaySlip
{
    protected PaySlip()
    {
        CollaboratorName = string.Empty;
        CollaboratorCode = string.Empty;
        Area = string.Empty;
        Period = string.Empty;
        PaymentType = string.Empty;
        PdfFileName = string.Empty;
    }

    public PaySlip(CreatePaySlipCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (command.CollaboratorId <= 0)
            throw new ArgumentException("Collaborator id is required.");

        if (string.IsNullOrWhiteSpace(command.CollaboratorName))
            throw new ArgumentException("Collaborator name is required.");

        if (string.IsNullOrWhiteSpace(command.CollaboratorCode))
            throw new ArgumentException("Collaborator code is required.");

        if (string.IsNullOrWhiteSpace(command.Period))
            throw new ArgumentException("Period is required.");

        if (command.GrossIncome < 0)
            throw new ArgumentException("Gross income cannot be negative.");

        if (command.Deductions < 0)
            throw new ArgumentException("Deductions cannot be negative.");

        if (command.Deductions > command.GrossIncome)
            throw new ArgumentException("Deductions cannot be greater than gross income.");

        CollaboratorId = command.CollaboratorId;
        CollaboratorName = command.CollaboratorName;
        CollaboratorCode = command.CollaboratorCode;
        Area = command.Area;
        Period = command.Period;
        PaymentType = string.IsNullOrWhiteSpace(command.PaymentType) ? "Remuneración" : command.PaymentType;
        GrossIncome = command.GrossIncome;
        Deductions = command.Deductions;
        IssueDate = command.IssueDate;
        PaymentDate = command.PaymentDate;
        PdfFileName = command.PdfFileName ?? string.Empty;
        Status = EPaySlipStatus.Pending;
    }

    public int Id { get; private set; }
    public int CollaboratorId { get; private set; }
    public string CollaboratorName { get; private set; }
    public string CollaboratorCode { get; private set; }
    public string Area { get; private set; }
    public string Period { get; private set; }
    public string PaymentType { get; private set; }
    public decimal GrossIncome { get; private set; }
    public decimal Deductions { get; private set; }
    public EPaySlipStatus Status { get; private set; }
    public DateTime IssueDate { get; private set; }
    public DateTime? PaymentDate { get; private set; }
    public string PdfFileName { get; private set; }

    public decimal NetIncome => GrossIncome - Deductions > 0 ? GrossIncome - Deductions : 0;
}
