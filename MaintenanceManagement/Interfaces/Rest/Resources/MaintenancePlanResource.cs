namespace Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest.Resources;

public record MaintenancePlanResource(
    int Id,
    int VehicleId,
    int? RelatedIncidentId,
    string MaintenanceType,
    DateOnly? ScheduledDate,
    decimal? TargetMileage,
    string Status,
    string? Notes,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt
);