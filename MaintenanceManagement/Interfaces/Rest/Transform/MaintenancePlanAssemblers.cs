using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Commands;
using Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest.Resources;

namespace Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest.Transform;

public static class MaintenancePlanAssemblers
{
    public static CreateMaintenancePlanCommand ToCommand(CreateMaintenancePlanResource resource)
    {
        return new CreateMaintenancePlanCommand(
            resource.VehicleId,
            resource.RelatedIncidentId,
            resource.MaintenanceType,
            resource.ScheduledDate,
            resource.TargetMileage,
            resource.Status,
            resource.Notes,
            resource.CreatedAt,
            resource.UpdatedAt);
    }

    public static UpdateMaintenancePlanCommand ToCommand(int id, UpdateMaintenancePlanResource resource)
    {
        return new UpdateMaintenancePlanCommand(
            id,
            resource.VehicleId,
            resource.RelatedIncidentId,
            resource.MaintenanceType,
            resource.ScheduledDate,
            resource.TargetMileage,
            resource.Status,
            resource.Notes,
            resource.CreatedAt,
            resource.UpdatedAt);
    }

    public static PatchMaintenancePlanCommand ToCommand(int id, PatchMaintenancePlanResource resource)
    {
        return new PatchMaintenancePlanCommand(
            id,
            resource.VehicleId,
            resource.RelatedIncidentId,
            resource.MaintenanceType,
            resource.ScheduledDate,
            resource.TargetMileage,
            resource.Status,
            resource.Notes,
            resource.CreatedAt,
            resource.UpdatedAt);
    }

    public static MaintenancePlanResource ToResource(MaintenancePlan entity)
    {
        return new MaintenancePlanResource(
            entity.Id,
            entity.VehicleId,
            entity.RelatedIncidentId,
            entity.MaintenanceType,
            entity.ScheduledDate,
            entity.TargetMileage,
            entity.Status,
            entity.Notes,
            entity.CreatedAt,
            entity.UpdatedAt);
    }
}