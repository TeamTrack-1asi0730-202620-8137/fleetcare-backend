namespace Fleet.Care.Platform.InspectionManagement.Domain.Model.Queries;

public record GetAllInspectionsQuery(
    int? VehicleId = null,
    int? ChecklistId = null,
    int? DriverId = null,
    string? Status = null);