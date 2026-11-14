namespace Fleet.Care.Platform.IncidentManagement.Interfaces.Rest.Resources;

public record UpdateIncidentEvidenceResource(
    int IncidentId,
    string FileUrl,
    string? Description,
    DateTimeOffset CreatedAt
);