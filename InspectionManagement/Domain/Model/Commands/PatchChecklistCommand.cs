namespace Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;

public record PatchChecklistCommand(
    int Id,
    string? Name,
    string? Description,
    bool? IsActive,
    DateTimeOffset? CreatedAt
);