namespace Fleet.Care.Platform.VehicleOperations.Domain.Model.Commands;

public record UpdateFuelRecordCommand(
    int Id,
    int VehicleId,
    int RegisteredByUserId,
    decimal Mileage,
    decimal Liters,
    decimal TotalCost,
    DateTimeOffset FueledAt,
    DateTimeOffset CreatedAt
);