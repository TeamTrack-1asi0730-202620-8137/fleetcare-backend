namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

public record UpdateChecklistItemResource(
    int ChecklistId,
    string Description,
    int SortOrder,
    bool IsRequired
);