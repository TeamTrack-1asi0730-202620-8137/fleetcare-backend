namespace Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;

public record CreateChecklistCommand(
    string Name,
    string? Description,
    bool IsActive,
    DateTimeOffset CreatedAt
);