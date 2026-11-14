namespace Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest.Resources;

public record MaintenancePartResource(
    int Id,
    int MaintenanceRecordId,
    string Name,
    int Quantity,
    decimal UnitCost
);