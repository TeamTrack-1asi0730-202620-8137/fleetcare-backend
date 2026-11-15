namespace Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest.Resources;

public record PatchMaintenancePartResource(
    int? MaintenanceRecordId,
    string? Name,
    int? Quantity,
    decimal? UnitCost
);