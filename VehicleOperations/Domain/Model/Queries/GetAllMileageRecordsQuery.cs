namespace Fleet.Care.Platform.VehicleOperations.Domain.Model.Queries;

public record GetAllMileageRecordsQuery(int? VehicleId = null, int? RegisteredByUserId = null);