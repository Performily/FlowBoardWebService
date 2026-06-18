using FlowboardAPI.Shared.Domain.Model.Entities;

namespace FlowboardAPI.Payroll.Domain.Model.Aggregates;

public partial class PaySlip : IAuditableEntity
{
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}