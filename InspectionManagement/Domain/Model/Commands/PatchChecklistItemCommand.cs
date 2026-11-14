namespace Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;

public record PatchChecklistItemCommand(
    int Id,
    int? ChecklistId,
    string? Description,
    int? SortOrder,
    bool? IsRequired
);