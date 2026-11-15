namespace Fleet.Care.Platform.FleetManagement.Domain.Model.Commands;

public record CreateVehicleCommand(
    int FleetId,
    string PlateNumber,
    string Brand,
    string Model,
    int Year,
    string? Vin,
    string Status,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt
);