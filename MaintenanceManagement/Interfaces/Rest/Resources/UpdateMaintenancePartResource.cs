namespace Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest.Resources;

public record UpdateMaintenancePartResource(
    int MaintenanceRecordId,
    string Name,
    int Quantity,
    decimal UnitCost
);