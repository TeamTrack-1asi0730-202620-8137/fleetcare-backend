namespace Fleet.Care.Platform.FleetManagement.Interfaces.Rest.Resources;

public record PatchVehicleResource(
    int? FleetId,
    string? PlateNumber,
    string? Brand,
    string? Model,
    int? Year,
    string? Vin,
    string? Status,
    DateTimeOffset? CreatedAt,
    DateTimeOffset? UpdatedAt
);