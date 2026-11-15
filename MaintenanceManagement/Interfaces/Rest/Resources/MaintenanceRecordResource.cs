namespace Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest.Resources;

public record MaintenanceRecordResource(
    int Id,
    int? MaintenancePlanId,
    int VehicleId,
    string MaintenanceType,
    DateOnly PerformedDate,
    decimal Mileage,
    string WorkDescription,
    decimal TotalCost,
    string? Notes,
    DateTimeOffset CreatedAt
);