namespace Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;

public record CreateChecklistItemCommand(
    int ChecklistId,
    string Description,
    int SortOrder,
    bool IsRequired
);