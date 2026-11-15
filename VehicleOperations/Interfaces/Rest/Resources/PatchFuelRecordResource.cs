namespace Fleet.Care.Platform.VehicleOperations.Interfaces.Rest.Resources;

public record PatchFuelRecordResource(
    int? VehicleId,
    int? RegisteredByUserId,
    decimal? Mileage,
    decimal? Liters,
    decimal? TotalCost,
    DateTimeOffset? FueledAt,
    DateTimeOffset? CreatedAt
);