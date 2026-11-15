using Fleet.Care.Platform.Shared.Domain.Model.Aggregates.Internal;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Commands;

namespace Fleet.Care.Platform.VehicleOperations.Domain.Model.Aggregates;

public class MileageRecord : AggregateRoot
{
    protected MileageRecord()
    {
    }

    public MileageRecord(CreateMileageRecordCommand command)
    {
        VehicleId = command.VehicleId;
        RegisteredByUserId = command.RegisteredByUserId;
        Mileage = command.Mileage;
        RecordedAt = command.RecordedAt;
        CreatedAt = command.CreatedAt;
    }

    public int Id { get; private set; }
    public int VehicleId { get; private set; }
    public int RegisteredByUserId { get; private set; }
    public decimal Mileage { get; private set; }
    public DateTimeOffset RecordedAt { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    public void Update(UpdateMileageRecordCommand command)
    {
        VehicleId = command.VehicleId;
        RegisteredByUserId = command.RegisteredByUserId;
        Mileage = command.Mileage;
        RecordedAt = command.RecordedAt;
        CreatedAt = command.CreatedAt;
    }

    public void Patch(PatchMileageRecordCommand command)
    {
        if (command.VehicleId is not null) VehicleId = command.VehicleId.Value;
        if (command.RegisteredByUserId is not null) RegisteredByUserId = command.RegisteredByUserId.Value;
        if (command.Mileage is not null) Mileage = command.Mileage.Value;
        if (command.RecordedAt is not null) RecordedAt = command.RecordedAt.Value;
        if (command.CreatedAt is not null) CreatedAt = command.CreatedAt.Value;
    }
}