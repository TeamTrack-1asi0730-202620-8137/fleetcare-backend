namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

public record UpdateChecklistResource(
    string Name,
    string? Description,
    bool IsActive,
    DateTimeOffset CreatedAt
);