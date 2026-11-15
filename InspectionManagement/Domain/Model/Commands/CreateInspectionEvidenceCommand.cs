namespace Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;

public record CreateInspectionEvidenceCommand(
    int InspectionId,
    string FileUrl,
    string? Description,
    DateTimeOffset CreatedAt
);