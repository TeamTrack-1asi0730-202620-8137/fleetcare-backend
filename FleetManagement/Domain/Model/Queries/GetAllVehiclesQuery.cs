namespace Fleet.Care.Platform.FleetManagement.Domain.Model.Queries;

public record GetAllVehiclesQuery(int? FleetId = null, string? PlateNumber = null, string? Status = null);