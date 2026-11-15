namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

public record CreateChecklistItemResource(
    int ChecklistId,
    string Description,
    int SortOrder,
    bool IsRequired
);