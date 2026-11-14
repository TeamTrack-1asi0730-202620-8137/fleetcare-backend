namespace Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;

public record PatchInspectionResultCommand(
    int Id,
    int? InspectionId,
    int? ChecklistItemId,
    string? Result,
    string? Observation
);