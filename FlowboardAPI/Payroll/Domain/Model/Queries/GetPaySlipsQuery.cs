namespace FlowboardAPI.Payroll.Domain.Model.Queries;

public record GetPaySlipsQuery(string? Period, string? Status, string? Search);