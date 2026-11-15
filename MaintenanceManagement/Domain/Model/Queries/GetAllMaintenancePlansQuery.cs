namespace Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Queries;

public record GetAllMaintenancePlansQuery(
    int? VehicleId = null,
    int? RelatedIncidentId = null,
    string? Status = null,
    string? MaintenanceType = null);