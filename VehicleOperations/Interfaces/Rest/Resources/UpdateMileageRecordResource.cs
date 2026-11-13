namespace Fleet.Care.Platform.VehicleOperations.Interfaces.Rest.Resources;

public record UpdateMileageRecordResource(
    int VehicleId,
    int RegisteredByUserId,
    decimal Mileage,
    DateTimeOffset RecordedAt,
    DateTimeOffset CreatedAt
);