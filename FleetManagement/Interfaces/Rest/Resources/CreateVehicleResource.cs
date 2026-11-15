namespace Fleet.Care.Platform.FleetManagement.Interfaces.Rest.Resources;

public record CreateVehicleResource(
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