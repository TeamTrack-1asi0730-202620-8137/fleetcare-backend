using Fleet.Care.Platform.Shared.Domain.Model.Aggregates.Internal;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Commands;

namespace Fleet.Care.Platform.VehicleOperations.Domain.Model.Aggregates;

public class FuelRecord : AggregateRoot
{
    protected FuelRecord()
    {
    }

    public FuelRecord(CreateFuelRecordCommand command)
    {
        VehicleId = command.VehicleId;
        RegisteredByUserId = command.RegisteredByUserId;
        Mileage = command.Mileage;
        Liters = command.Liters;
        TotalCost = command.TotalCost;
        FueledAt = command.FueledAt;
        CreatedAt = command.CreatedAt;
    }

    public int Id { get; private set; }
    public int VehicleId { get; private set; }
    public int RegisteredByUserId { get; private set; }
    public decimal Mileage { get; private set; }
    public decimal Liters { get; private set; }
    public decimal TotalCost { get; private set; }
    public DateTimeOffset FueledAt { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    public void Update(UpdateFuelRecordCommand command)
    {
        VehicleId = command.VehicleId;
        RegisteredByUserId = command.RegisteredByUserId;
        Mileage = command.Mileage;
        Liters = command.Liters;
        TotalCost = command.TotalCost;
        FueledAt = command.FueledAt;
        CreatedAt = command.CreatedAt;
    }

    public void Patch(PatchFuelRecordCommand command)
    {
        if (command.VehicleId is not null) VehicleId = command.VehicleId.Value;
        if (command.RegisteredByUserId is not null) RegisteredByUserId = command.RegisteredByUserId.Value;
        if (command.Mileage is not null) Mileage = command.Mileage.Value;
        if (command.Liters is not null) Liters = command.Liters.Value;
        if (command.TotalCost is not null) TotalCost = command.TotalCost.Value;
        if (command.FueledAt is not null) FueledAt = command.FueledAt.Value;
        if (command.CreatedAt is not null) CreatedAt = command.CreatedAt.Value;
    }
}