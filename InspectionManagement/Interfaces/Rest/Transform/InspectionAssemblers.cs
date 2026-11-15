using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;
using Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Transform;

public static class InspectionAssemblers
{
    public static CreateInspectionCommand ToCommand(CreateInspectionResource resource)
    {
        return new CreateInspectionCommand(
            resource.VehicleId,
            resource.ChecklistId,
            resource.DriverId,
            resource.InspectionDate,
            resource.Status,
            resource.Observation,
            resource.CreatedAt,
            resource.CompletedAt);
    }

    public static UpdateInspectionCommand ToCommand(int id, UpdateInspectionResource resource)
    {
        return new UpdateInspectionCommand(
            id,
            resource.VehicleId,
            resource.ChecklistId,
            resource.DriverId,
            resource.InspectionDate,
            resource.Status,
            resource.Observation,
            resource.CreatedAt,
            resource.CompletedAt);
    }

    public static PatchInspectionCommand ToCommand(int id, PatchInspectionResource resource)
    {
        return new PatchInspectionCommand(
            id,
            resource.VehicleId,
            resource.ChecklistId,
            resource.DriverId,
            resource.InspectionDate,
            resource.Status,
            resource.Observation,
            resource.CreatedAt,
            resource.CompletedAt);
    }

    public static InspectionResource ToResource(Inspection entity)
    {
        return new InspectionResource(
            entity.Id,
            entity.VehicleId,
            entity.ChecklistId,
            entity.DriverId,
            entity.InspectionDate,
            entity.Status,
            entity.Observation,
            entity.CreatedAt,
            entity.CompletedAt);
    }
}