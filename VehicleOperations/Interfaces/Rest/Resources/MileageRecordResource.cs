namespace Fleet.Care.Platform.VehicleOperations.Interfaces.Rest.Resources;

public record MileageRecordResource(
    int Id,
    int VehicleId,
    int RegisteredByUserId,
    decimal Mileage,
    DateTimeOffset RecordedAt,
    DateTimeOffset CreatedAt
);