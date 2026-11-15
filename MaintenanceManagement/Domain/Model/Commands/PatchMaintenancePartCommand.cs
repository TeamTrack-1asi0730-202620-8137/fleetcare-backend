namespace Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Commands;

public record PatchMaintenancePartCommand(
    int Id,
    int? MaintenanceRecordId,
    string? Name,
    int? Quantity,
    decimal? UnitCost
);