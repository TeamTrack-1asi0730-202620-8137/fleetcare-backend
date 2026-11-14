namespace Fleet.Care.Platform.IncidentManagement.Domain.Model.Commands;

public record PatchIncidentEvidenceCommand(
    int Id,
    int? IncidentId,
    string? FileUrl,
    string? Description,
    DateTimeOffset? CreatedAt
);