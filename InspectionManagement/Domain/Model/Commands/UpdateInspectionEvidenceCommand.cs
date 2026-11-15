namespace Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;

public record UpdateInspectionEvidenceCommand(
    int Id,
    int InspectionId,
    string FileUrl,
    string? Description,
    DateTimeOffset CreatedAt
);