using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Domain.Model.Aggregates.Internal;

namespace Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;

public class MaintenancePart : AggregateRoot
{
    protected MaintenancePart()
    {
    }

    public MaintenancePart(CreateMaintenancePartCommand command)
    {
        MaintenanceRecordId = command.MaintenanceRecordId;
        Name = command.Name;
        Quantity = command.Quantity;
        UnitCost = command.UnitCost;
    }

    public int Id { get; private set; }
    public int MaintenanceRecordId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public int Quantity { get; private set; }
    public decimal UnitCost { get; private set; }

    public void Update(UpdateMaintenancePartCommand command)
    {
        MaintenanceRecordId = command.MaintenanceRecordId;
        Name = command.Name;
        Quantity = command.Quantity;
        UnitCost = command.UnitCost;
    }

    public void Patch(PatchMaintenancePartCommand command)
    {
        if (command.MaintenanceRecordId is not null) MaintenanceRecordId = command.MaintenanceRecordId.Value;
        if (command.Name is not null) Name = command.Name;
        if (command.Quantity is not null) Quantity = command.Quantity.Value;
        if (command.UnitCost is not null) UnitCost = command.UnitCost.Value;
    }
}