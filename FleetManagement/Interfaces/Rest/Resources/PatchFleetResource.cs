namespace Fleet.Care.Platform.FleetManagement.Interfaces.Rest.Resources;

public record PatchFleetResource(
    string? Name,
    DateTimeOffset? CreatedAt,
    DateTimeOffset? UpdatedAt
);