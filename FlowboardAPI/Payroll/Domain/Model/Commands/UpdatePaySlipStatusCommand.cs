namespace FlowboardAPI.Payroll.Domain.Model.Commands;

public record UpdatePaySlipStatusCommand(int PaySlipId, string Status);