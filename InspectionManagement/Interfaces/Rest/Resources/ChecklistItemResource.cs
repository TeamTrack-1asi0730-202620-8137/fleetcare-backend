namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

public record ChecklistItemResource(
    int Id,
    int ChecklistId,
    string Description,
    int SortOrder,
    bool IsRequired
);