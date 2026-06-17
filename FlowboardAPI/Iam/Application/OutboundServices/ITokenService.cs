using Performily.IAM.Iam.Domain.Model.Aggregates;

namespace Performily.IAM.Iam.Application.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
}