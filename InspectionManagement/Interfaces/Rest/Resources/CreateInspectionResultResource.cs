namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

public record CreateInspectionResultResource(
    int InspectionId,
    int ChecklistItemId,
    string Result,
    string? Observation
);