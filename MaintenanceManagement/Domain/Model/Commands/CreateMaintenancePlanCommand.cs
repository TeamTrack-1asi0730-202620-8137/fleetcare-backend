namespace Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Commands;

public record CreateMaintenancePlanCommand(
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