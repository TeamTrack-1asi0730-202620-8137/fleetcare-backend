namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

public record PatchInspectionEvidenceResource(
    int? InspectionId,
    string? FileUrl,
    string? Description,
    DateTimeOffset? CreatedAt
);