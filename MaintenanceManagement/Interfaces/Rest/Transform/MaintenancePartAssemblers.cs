using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Commands;
using Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest.Resources;

namespace Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest.Transform;

public static class MaintenancePartAssemblers
{
    public static CreateMaintenancePartCommand ToCommand(CreateMaintenancePartResource resource)
    {
        return new CreateMaintenancePartCommand(
            resource.MaintenanceRecordId,
            resource.Name,
            resource.Quantity,
            resource.UnitCost);
    }

    public static UpdateMaintenancePartCommand ToCommand(int id, UpdateMaintenancePartResource resource)
    {
        return new UpdateMaintenancePartCommand(
            id,
            resource.MaintenanceRecordId,
            resource.Name,
            resource.Quantity,
            resource.UnitCost);
    }

    public static PatchMaintenancePartCommand ToCommand(int id, PatchMaintenancePartResource resource)
    {
        return new PatchMaintenancePartCommand(
            id,
            resource.MaintenanceRecordId,
            resource.Name,
            resource.Quantity,
            resource.UnitCost);
    }

    public static MaintenancePartResource ToResource(MaintenancePart entity)
    {
        return new MaintenancePartResource(
            entity.Id,
            entity.MaintenanceRecordId,
            entity.Name,
            entity.Quantity,
            entity.UnitCost);
    }
}