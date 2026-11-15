namespace Fleet.Care.Platform.FleetManagement.Interfaces.Rest.Resources;

public record UpdateFleetResource(
    string Name,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt
);