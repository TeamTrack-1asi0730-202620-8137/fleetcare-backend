namespace Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Commands;

public record CreateMaintenancePartCommand(
    int MaintenanceRecordId,
    string Name,
    int Quantity,
    decimal UnitCost
);