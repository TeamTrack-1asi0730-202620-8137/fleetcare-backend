namespace Fleet.Care.Platform.VehicleOperations.Domain.Model.Queries;

public record GetAllFuelRecordsQuery(int? VehicleId = null, int? RegisteredByUserId = null);