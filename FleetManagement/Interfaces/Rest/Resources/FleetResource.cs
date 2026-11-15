namespace Fleet.Care.Platform.FleetManagement.Interfaces.Rest.Resources;

public record FleetResource(
    int Id,
    string Name,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt
);