namespace FlowboardAPI.Requests.Interfaces.Rest.Resources;

public record RejectRequestResource(
    int ReviewerId,
    string Reason
);