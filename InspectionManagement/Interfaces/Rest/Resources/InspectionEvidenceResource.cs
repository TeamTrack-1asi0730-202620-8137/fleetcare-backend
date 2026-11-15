namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

public record InspectionEvidenceResource(
    int Id,
    int InspectionId,
    string FileUrl,
    string? Description,
    DateTimeOffset CreatedAt
);