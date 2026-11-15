namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

public record UpdateInspectionEvidenceResource(
    int InspectionId,
    string FileUrl,
    string? Description,
    DateTimeOffset CreatedAt
);