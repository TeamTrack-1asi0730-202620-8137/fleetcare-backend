namespace Fleet.Care.Platform.VehicleOperations.Domain.Model.Commands;

public record PatchMileageRecordCommand(
    int Id,
    int? VehicleId,
    int? RegisteredByUserId,
    decimal? Mileage,
    DateTimeOffset? RecordedAt,
    DateTimeOffset? CreatedAt
);