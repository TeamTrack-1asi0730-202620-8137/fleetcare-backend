namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

public record PatchChecklistItemResource(
    int? ChecklistId,
    string? Description,
    int? SortOrder,
    bool? IsRequired
);