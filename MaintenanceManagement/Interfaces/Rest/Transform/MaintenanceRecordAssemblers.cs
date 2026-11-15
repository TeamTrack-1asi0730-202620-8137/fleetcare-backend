using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Commands;
using Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest.Resources;

namespace Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest.Transform;

public static class MaintenanceRecordAssemblers
{
    public static CreateMaintenanceRecordCommand ToCommand(CreateMaintenanceRecordResource resource)
    {
        return new CreateMaintenanceRecordCommand(
            resource.MaintenancePlanId,
            resource.VehicleId,
            resource.MaintenanceType,
            resource.PerformedDate,
            resource.Mileage,
            resource.WorkDescription,
            resource.TotalCost,
            resource.Notes,
            resource.CreatedAt);
    }

    public static UpdateMaintenanceRecordCommand ToCommand(int id, UpdateMaintenanceRecordResource resource)
    {
        return new UpdateMaintenanceRecordCommand(
            id,
            resource.MaintenancePlanId,
            resource.VehicleId,
            resource.MaintenanceType,
            resource.PerformedDate,
            resource.Mileage,
            resource.WorkDescription,
            resource.TotalCost,
            resource.Notes,
            resource.CreatedAt);
    }

    public static PatchMaintenanceRecordCommand ToCommand(int id, PatchMaintenanceRecordResource resource)
    {
        return new PatchMaintenanceRecordCommand(
            id,
            resource.MaintenancePlanId,
            resource.VehicleId,
            resource.MaintenanceType,
            resource.PerformedDate,
            resource.Mileage,
            resource.WorkDescription,
            resource.TotalCost,
            resource.Notes,
            resource.CreatedAt);
    }

    public static MaintenanceRecordResource ToResource(MaintenanceRecord entity)
    {
        return new MaintenanceRecordResource(
            entity.Id,
            entity.MaintenancePlanId,
            entity.VehicleId,
            entity.MaintenanceType,
            entity.PerformedDate,
            entity.Mileage,
            entity.WorkDescription,
            entity.TotalCost,
            entity.Notes,
            entity.CreatedAt);
    }
}