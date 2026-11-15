using Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.FleetManagement.Domain.Model.Commands;
using Fleet.Care.Platform.FleetManagement.Interfaces.Rest.Resources;

namespace Fleet.Care.Platform.FleetManagement.Interfaces.Rest.Transform;

public static class FleetAssemblers
{
    public static CreateFleetCommand ToCommand(CreateFleetResource resource)
    {
        return new CreateFleetCommand(
            resource.Name,
            resource.CreatedAt,
            resource.UpdatedAt);
    }

    public static UpdateFleetCommand ToCommand(int id, UpdateFleetResource resource)
    {
        return new UpdateFleetCommand(
            id,
            resource.Name,
            resource.CreatedAt,
            resource.UpdatedAt);
    }

    public static PatchFleetCommand ToCommand(int id, PatchFleetResource resource)
    {
        return new PatchFleetCommand(
            id,
            resource.Name,
            resource.CreatedAt,
            resource.UpdatedAt);
    }

    public static FleetResource ToResource(FleetAggregate entity)
    {
        return new FleetResource(
            entity.Id,
            entity.Name,
            entity.CreatedAt,
            entity.UpdatedAt);
    }
}