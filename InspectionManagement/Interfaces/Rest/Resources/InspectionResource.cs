namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

public record InspectionResource(
    int Id,
    int VehicleId,
    int ChecklistId,
    int DriverId,
    DateTimeOffset InspectionDate,
    string Status,
    string? Observation,
    DateTimeOffset CreatedAt,
    DateTimeOffset? CompletedAt
);