namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

public record InspectionResultResource(
    int Id,
    int InspectionId,
    int ChecklistItemId,
    string Result,
    string? Observation
);