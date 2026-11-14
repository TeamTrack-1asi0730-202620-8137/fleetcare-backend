namespace Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;

public record CreateInspectionCommand(
    int VehicleId,
    int ChecklistId,
    int DriverId,
    DateTimeOffset InspectionDate,
    string Status,
    string? Observation,
    DateTimeOffset CreatedAt,
    DateTimeOffset? CompletedAt
);