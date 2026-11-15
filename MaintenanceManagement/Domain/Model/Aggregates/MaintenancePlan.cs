using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Domain.Model.Aggregates.Internal;

namespace Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;

public class MaintenancePlan : AggregateRoot
{
    protected MaintenancePlan()
    {
    }

    public MaintenancePlan(CreateMaintenancePlanCommand command)
    {
        VehicleId = command.VehicleId;
        RelatedIncidentId = command.RelatedIncidentId;
        MaintenanceType = command.MaintenanceType;
        ScheduledDate = command.ScheduledDate;
        TargetMileage = command.TargetMileage;
        Status = command.Status;
        Notes = command.Notes;
        CreatedAt = command.CreatedAt;
        UpdatedAt = command.UpdatedAt;
    }

    public int Id { get; private set; }
    public int VehicleId { get; private set; }
    public int? RelatedIncidentId { get; private set; }
    public string MaintenanceType { get; private set; } = string.Empty;
    public DateOnly? ScheduledDate { get; private set; }
    public decimal? TargetMileage { get; private set; }
    public string Status { get; private set; } = string.Empty;
    public string? Notes { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset UpdatedAt { get; private set; }

    public void Update(UpdateMaintenancePlanCommand command)
    {
        VehicleId = command.VehicleId;
        RelatedIncidentId = command.RelatedIncidentId;
        MaintenanceType = command.MaintenanceType;
        ScheduledDate = command.ScheduledDate;
        TargetMileage = command.TargetMileage;
        Status = command.Status;
        Notes = command.Notes;
        CreatedAt = command.CreatedAt;
        UpdatedAt = command.UpdatedAt;
    }

    public void Patch(PatchMaintenancePlanCommand command)
    {
        if (command.VehicleId is not null) VehicleId = command.VehicleId.Value;
        if (command.RelatedIncidentId is not null) RelatedIncidentId = command.RelatedIncidentId;
        if (command.MaintenanceType is not null) MaintenanceType = command.MaintenanceType;
        if (command.ScheduledDate is not null) ScheduledDate = command.ScheduledDate;
        if (command.TargetMileage is not null) TargetMileage = command.TargetMileage;
        if (command.Status is not null) Status = command.Status;
        if (command.Notes is not null) Notes = command.Notes;
        if (command.CreatedAt is not null) CreatedAt = command.CreatedAt.Value;
        if (command.UpdatedAt is not null) UpdatedAt = command.UpdatedAt.Value;
    }
}