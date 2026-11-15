namespace Fleet.Care.Platform.FleetManagement.Domain.Model.Commands;

public record CreateFleetCommand(
    string Name,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt
);