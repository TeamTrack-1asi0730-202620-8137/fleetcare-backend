namespace Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;

public record CreateInspectionResultCommand(
    int InspectionId,
    int ChecklistItemId,
    string Result,
    string? Observation
);