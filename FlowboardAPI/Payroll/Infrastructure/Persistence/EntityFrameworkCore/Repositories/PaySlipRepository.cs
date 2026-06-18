using FlowboardAPI.Payroll.Domain.Model.Aggregates;
using FlowboardAPI.Payroll.Domain.Model.ValueObjects;
using FlowboardAPI.Payroll.Domain.Repositories;
using FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using FlowboardAPI.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlowboardAPI.Payroll.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class PaySlipRepository(AppDbContext context)
    : BaseRepository<PaySlip>(context), IPaySlipRepository
{
    public async Task<IEnumerable<PaySlip>> ListAsync(string? period, string? status, string? search, CancellationToken cancellationToken)
    {
        var query = Context.Set<PaySlip>().AsQueryable();

        if (!string.IsNullOrWhiteSpace(period))
            query = query.Where(paySlip => paySlip.Period == period);

        if (!string.IsNullOrWhiteSpace(status))
        {
            var statusValue = StatusFromText(status);
            query = query.Where(paySlip => paySlip.Status == statusValue);
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(paySlip =>
                paySlip.CollaboratorName.Contains(search) ||
                paySlip.CollaboratorCode.Contains(search) ||
                paySlip.Area.Contains(search));
        }

        return await query
            .OrderByDescending(paySlip => paySlip.IssueDate)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<PaySlip>> FindByCollaboratorIdAsync(int collaboratorId, CancellationToken cancellationToken)
    {
        return await Context.Set<PaySlip>()
            .Where(paySlip => paySlip.CollaboratorId == collaboratorId)
            .OrderByDescending(paySlip => paySlip.IssueDate)
            .ToListAsync(cancellationToken);
    }

    private static EPaySlipStatus StatusFromText(string status)
    {
        return status.Trim() switch
        {
            "Pagado" or "Paid" => EPaySlipStatus.Paid,
            "Con observación" or "WithObservation" => EPaySlipStatus.WithObservation,
            "Pendiente" or "Pending" => EPaySlipStatus.Pending,
            _ => throw new ArgumentException("Invalid pay slip status.")
        };
    }
}
