namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

public record PatchInspectionResultResource(
    int? InspectionId,
    int? ChecklistItemId,
    string? Result,
    string? Observation
);