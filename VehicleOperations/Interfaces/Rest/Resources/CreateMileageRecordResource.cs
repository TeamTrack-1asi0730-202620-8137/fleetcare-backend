namespace Fleet.Care.Platform.VehicleOperations.Interfaces.Rest.Resources;

public record CreateMileageRecordResource(
    int VehicleId,
    int RegisteredByUserId,
    decimal Mileage,
    DateTimeOffset RecordedAt,
    DateTimeOffset CreatedAt
);