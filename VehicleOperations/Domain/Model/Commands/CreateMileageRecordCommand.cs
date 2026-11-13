namespace Fleet.Care.Platform.VehicleOperations.Domain.Model.Commands;

public record CreateMileageRecordCommand(
    int VehicleId,
    int RegisteredByUserId,
    decimal Mileage,
    DateTimeOffset RecordedAt,
    DateTimeOffset CreatedAt
);