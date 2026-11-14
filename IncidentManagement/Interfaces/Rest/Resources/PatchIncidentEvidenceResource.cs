namespace Fleet.Care.Platform.IncidentManagement.Interfaces.Rest.Resources;

public record PatchIncidentEvidenceResource(
    int? IncidentId,
    string? FileUrl,
    string? Description,
    DateTimeOffset? CreatedAt
);