namespace Fleet.Care.Platform.FleetManagement.Domain.Model.Commands;

public record UpdateFleetCommand(
    int Id,
    string Name,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt
);