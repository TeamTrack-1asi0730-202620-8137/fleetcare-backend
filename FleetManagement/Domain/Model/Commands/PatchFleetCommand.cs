namespace Fleet.Care.Platform.FleetManagement.Domain.Model.Commands;

public record PatchFleetCommand(
    int Id,
    string? Name,
    DateTimeOffset? CreatedAt,
    DateTimeOffset? UpdatedAt
);