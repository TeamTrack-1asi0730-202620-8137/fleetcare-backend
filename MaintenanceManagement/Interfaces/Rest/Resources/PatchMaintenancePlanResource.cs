namespace Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest.Resources;

public record PatchMaintenancePlanResource(
    int? VehicleId,
    int? RelatedIncidentId,
    string? MaintenanceType,
    DateOnly? ScheduledDate,
    decimal? TargetMileage,
    string? Status,
    string? Notes,
    DateTimeOffset? CreatedAt,
    DateTimeOffset? UpdatedAt
);