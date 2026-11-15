namespace Fleet.Care.Platform.FleetManagement.Interfaces.Rest.Resources;

public record CreateFleetResource(
    string Name,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt
);