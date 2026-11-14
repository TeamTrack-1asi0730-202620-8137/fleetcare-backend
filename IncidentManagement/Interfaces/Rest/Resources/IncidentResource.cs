namespace Fleet.Care.Platform.IncidentManagement.Interfaces.Rest.Resources;

public record IncidentResource(
    int Id,
    int VehicleId,
    int ReportedByUserId,
    int? SourceInspectionId,
    string Title,
    string Description,
    string Status,
    decimal? Latitude,
    decimal? Longitude,
    string? Address,
    DateTimeOffset ReportedAt,
    DateTimeOffset? ResolvedAt,
    string? Resolution,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt
);