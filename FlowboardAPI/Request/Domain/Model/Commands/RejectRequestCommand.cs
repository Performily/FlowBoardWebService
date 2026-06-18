namespace FlowboardAPI.Requests.Domain.Model.Commands;

public record RejectRequestCommand(int RequestId, int ReviewerId, string Reason);