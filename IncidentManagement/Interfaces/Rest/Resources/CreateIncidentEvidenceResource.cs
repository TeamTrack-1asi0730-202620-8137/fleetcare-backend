namespace Fleet.Care.Platform.IncidentManagement.Interfaces.Rest.Resources;

public record CreateIncidentEvidenceResource(
    int IncidentId,
    string FileUrl,
    string? Description,
    DateTimeOffset CreatedAt
);