namespace Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Commands;

public record PatchMaintenanceRecordCommand(
    int Id,
    int? MaintenancePlanId,
    int? VehicleId,
    string? MaintenanceType,
    DateOnly? PerformedDate,
    decimal? Mileage,
    string? WorkDescription,
    decimal? TotalCost,
    string? Notes,
    DateTimeOffset? CreatedAt
);