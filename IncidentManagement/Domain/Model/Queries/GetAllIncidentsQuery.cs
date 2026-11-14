namespace Fleet.Care.Platform.IncidentManagement.Domain.Model.Queries;

public record GetAllIncidentsQuery(
    int? VehicleId = null,
    int? ReportedByUserId = null,
    string? Status = null,
    int? SourceInspectionId = null);