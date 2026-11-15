namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

public record ChecklistResource(
    int Id,
    string Name,
    string? Description,
    bool IsActive,
    DateTimeOffset CreatedAt
);