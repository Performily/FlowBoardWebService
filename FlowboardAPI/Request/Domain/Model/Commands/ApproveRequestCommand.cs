namespace FlowboardAPI.Requests.Domain.Model.Commands;

public record ApproveRequestCommand(int RequestId, int ReviewerId);