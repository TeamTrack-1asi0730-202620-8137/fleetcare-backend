namespace Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Queries;

public record GetAllMaintenanceRecordsQuery(
    int? MaintenancePlanId = null,
    int? VehicleId = null,
    string? MaintenanceType = null);