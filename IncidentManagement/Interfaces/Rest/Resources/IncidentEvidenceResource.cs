namespace Fleet.Care.Platform.IncidentManagement.Interfaces.Rest.Resources;

public record IncidentEvidenceResource(
    int Id,
    int IncidentId,
    string FileUrl,
    string? Description,
    DateTimeOffset CreatedAt
);