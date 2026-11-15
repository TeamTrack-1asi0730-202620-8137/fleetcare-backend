namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

public record CreateChecklistResource(
    string Name,
    string? Description,
    bool IsActive,
    DateTimeOffset CreatedAt
);