namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

public record CreateInspectionEvidenceResource(
    int InspectionId,
    string FileUrl,
    string? Description,
    DateTimeOffset CreatedAt
);