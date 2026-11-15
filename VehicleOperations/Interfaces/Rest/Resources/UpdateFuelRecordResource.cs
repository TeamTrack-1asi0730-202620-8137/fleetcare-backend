namespace Fleet.Care.Platform.VehicleOperations.Interfaces.Rest.Resources;

public record UpdateFuelRecordResource(
    int VehicleId,
    int RegisteredByUserId,
    decimal Mileage,
    decimal Liters,
    decimal TotalCost,
    DateTimeOffset FueledAt,
    DateTimeOffset CreatedAt
);