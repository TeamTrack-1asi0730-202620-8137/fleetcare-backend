namespace Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;

public record PatchInspectionEvidenceCommand(
    int Id,
    int? InspectionId,
    string? FileUrl,
    string? Description,
    DateTimeOffset? CreatedAt
);