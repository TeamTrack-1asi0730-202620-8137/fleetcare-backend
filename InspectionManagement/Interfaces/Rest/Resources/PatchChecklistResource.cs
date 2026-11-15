namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

public record PatchChecklistResource(
    string? Name,
    string? Description,
    bool? IsActive,
    DateTimeOffset? CreatedAt
);