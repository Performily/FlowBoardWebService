using FlowboardAPI.Iam.Domain.Model.Aggregates;

namespace FlowboardAPI.Iam.Application.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
}