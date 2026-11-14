namespace Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest.Resources;

public record CreateMaintenancePartResource(
    int MaintenanceRecordId,
    string Name,
    int Quantity,
    decimal UnitCost
);