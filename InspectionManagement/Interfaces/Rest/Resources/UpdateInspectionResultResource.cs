namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

public record UpdateInspectionResultResource(
    int InspectionId,
    int ChecklistItemId,
    string Result,
    string? Observation
);