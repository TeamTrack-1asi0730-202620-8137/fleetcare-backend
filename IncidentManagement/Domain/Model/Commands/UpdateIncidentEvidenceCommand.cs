namespace Fleet.Care.Platform.IncidentManagement.Domain.Model.Commands;

public record UpdateIncidentEvidenceCommand(
    int Id,
    int IncidentId,
    string FileUrl,
    string? Description,
    DateTimeOffset CreatedAt
);