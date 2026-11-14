namespace Fleet.Care.Platform.IncidentManagement.Domain.Model.Commands;

public record CreateIncidentEvidenceCommand(
    int IncidentId,
    string FileUrl,
    string? Description,
    DateTimeOffset CreatedAt
);