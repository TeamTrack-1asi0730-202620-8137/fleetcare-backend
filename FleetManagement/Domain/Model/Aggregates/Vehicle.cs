using Fleet.Care.Platform.FleetManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Domain.Model.Aggregates.Internal;

namespace Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;

public class Vehicle : AggregateRoot
{
    protected Vehicle()
    {
    }

    public Vehicle(CreateVehicleCommand command)
    {
        FleetId = command.FleetId;
        PlateNumber = command.PlateNumber;
        Brand = command.Brand;
        Model = command.Model;
        Year = command.Year;
        Vin = command.Vin;
        Status = command.Status;
        CreatedAt = command.CreatedAt;
        UpdatedAt = command.UpdatedAt;
    }

    public int Id { get; private set; }
    public int FleetId { get; private set; }
    public string PlateNumber { get; private set; } = string.Empty;
    public string Brand { get; private set; } = string.Empty;
    public string Model { get; private set; } = string.Empty;
    public int Year { get; private set; }
    public string? Vin { get; private set; }
    public string Status { get; private set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset UpdatedAt { get; private set; }

    public void Update(UpdateVehicleCommand command)
    {
        FleetId = command.FleetId;
        PlateNumber = command.PlateNumber;
        Brand = command.Brand;
        Model = command.Model;
        Year = command.Year;
        Vin = command.Vin;
        Status = command.Status;
        CreatedAt = command.CreatedAt;
        UpdatedAt = command.UpdatedAt;
    }

    public void Patch(PatchVehicleCommand command)
    {
        if (command.FleetId is not null) FleetId = command.FleetId.Value;
        if (command.PlateNumber is not null) PlateNumber = command.PlateNumber;
        if (command.Brand is not null) Brand = command.Brand;
        if (command.Model is not null) Model = command.Model;
        if (command.Year is not null) Year = command.Year.Value;
        if (command.Vin is not null) Vin = command.Vin;
        if (command.Status is not null) Status = command.Status;
        if (command.CreatedAt is not null) CreatedAt = command.CreatedAt.Value;
        if (command.UpdatedAt is not null) UpdatedAt = command.UpdatedAt.Value;
    }
}