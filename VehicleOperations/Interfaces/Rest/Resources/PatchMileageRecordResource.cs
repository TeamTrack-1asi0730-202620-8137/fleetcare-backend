namespace Fleet.Care.Platform.VehicleOperations.Interfaces.Rest.Resources;

public record PatchMileageRecordResource(
    int? VehicleId,
    int? RegisteredByUserId,
    decimal? Mileage,
    DateTimeOffset? RecordedAt,
    DateTimeOffset? CreatedAt
);