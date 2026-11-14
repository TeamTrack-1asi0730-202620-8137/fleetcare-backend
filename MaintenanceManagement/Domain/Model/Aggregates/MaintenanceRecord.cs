using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Domain.Model.Aggregates.Internal;

namespace Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;

public class MaintenanceRecord : AggregateRoot
{
    protected MaintenanceRecord()
    {
    }

    public MaintenanceRecord(CreateMaintenanceRecordCommand command)
    {
        MaintenancePlanId = command.MaintenancePlanId;
        VehicleId = command.VehicleId;
        MaintenanceType = command.MaintenanceType;
        PerformedDate = command.PerformedDate;
        Mileage = command.Mileage;
        WorkDescription = command.WorkDescription;
        TotalCost = command.TotalCost;
        Notes = command.Notes;
        CreatedAt = command.CreatedAt;
    }

    public int Id { get; private set; }
    public int? MaintenancePlanId { get; private set; }
    public int VehicleId { get; private set; }
    public string MaintenanceType { get; private set; } = string.Empty;
    public DateOnly PerformedDate { get; private set; }
    public decimal Mileage { get; private set; }
    public string WorkDescription { get; private set; } = string.Empty;
    public decimal TotalCost { get; private set; }
    public string? Notes { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    public void Update(UpdateMaintenanceRecordCommand command)
    {
        MaintenancePlanId = command.MaintenancePlanId;
        VehicleId = command.VehicleId;
        MaintenanceType = command.MaintenanceType;
        PerformedDate = command.PerformedDate;
        Mileage = command.Mileage;
        WorkDescription = command.WorkDescription;
        TotalCost = command.TotalCost;
        Notes = command.Notes;
        CreatedAt = command.CreatedAt;
    }

    public void Patch(PatchMaintenanceRecordCommand command)
    {
        if (command.MaintenancePlanId is not null) MaintenancePlanId = command.MaintenancePlanId;
        if (command.VehicleId is not null) VehicleId = command.VehicleId.Value;
        if (command.MaintenanceType is not null) MaintenanceType = command.MaintenanceType;
        if (command.PerformedDate is not null) PerformedDate = command.PerformedDate.Value;
        if (command.Mileage is not null) Mileage = command.Mileage.Value;
        if (command.WorkDescription is not null) WorkDescription = command.WorkDescription;
        if (command.TotalCost is not null) TotalCost = command.TotalCost.Value;
        if (command.Notes is not null) Notes = command.Notes;
        if (command.CreatedAt is not null) CreatedAt = command.CreatedAt.Value;
    }
}