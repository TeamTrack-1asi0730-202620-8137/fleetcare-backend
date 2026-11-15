using Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Domain.Model.Aggregates.Internal;

namespace Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;

public class Inspection : AggregateRoot
{
    protected Inspection()
    {
    }

    public Inspection(CreateInspectionCommand command)
    {
        VehicleId = command.VehicleId;
        ChecklistId = command.ChecklistId;
        DriverId = command.DriverId;
        InspectionDate = command.InspectionDate;
        Status = command.Status;
        Observation = command.Observation;
        CreatedAt = command.CreatedAt;
        CompletedAt = command.CompletedAt;
    }

    public int Id { get; private set; }
    public int VehicleId { get; private set; }
    public int ChecklistId { get; private set; }
    public int DriverId { get; private set; }
    public DateTimeOffset InspectionDate { get; private set; }
    public string Status { get; private set; } = string.Empty;
    public string? Observation { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset? CompletedAt { get; private set; }

    public void Update(UpdateInspectionCommand command)
    {
        VehicleId = command.VehicleId;
        ChecklistId = command.ChecklistId;
        DriverId = command.DriverId;
        InspectionDate = command.InspectionDate;
        Status = command.Status;
        Observation = command.Observation;
        CreatedAt = command.CreatedAt;
        CompletedAt = command.CompletedAt;
    }

    public void Patch(PatchInspectionCommand command)
    {
        if (command.VehicleId is not null) VehicleId = command.VehicleId.Value;
        if (command.ChecklistId is not null) ChecklistId = command.ChecklistId.Value;
        if (command.DriverId is not null) DriverId = command.DriverId.Value;
        if (command.InspectionDate is not null) InspectionDate = command.InspectionDate.Value;
        if (command.Status is not null) Status = command.Status;
        if (command.Observation is not null) Observation = command.Observation;
        if (command.CreatedAt is not null) CreatedAt = command.CreatedAt.Value;
        if (command.CompletedAt is not null) CompletedAt = command.CompletedAt;
    }
}