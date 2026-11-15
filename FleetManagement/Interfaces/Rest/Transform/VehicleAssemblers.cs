using Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.FleetManagement.Domain.Model.Commands;
using Fleet.Care.Platform.FleetManagement.Interfaces.Rest.Resources;

namespace Fleet.Care.Platform.FleetManagement.Interfaces.Rest.Transform;

public static class VehicleAssemblers
{
    public static CreateVehicleCommand ToCommand(CreateVehicleResource resource)
    {
        return new CreateVehicleCommand(
            resource.FleetId,
            resource.PlateNumber,
            resource.Brand,
            resource.Model,
            resource.Year,
            resource.Vin,
            resource.Status,
            resource.CreatedAt,
            resource.UpdatedAt);
    }

    public static UpdateVehicleCommand ToCommand(int id, UpdateVehicleResource resource)
    {
        return new UpdateVehicleCommand(
            id,
            resource.FleetId,
            resource.PlateNumber,
            resource.Brand,
            resource.Model,
            resource.Year,
            resource.Vin,
            resource.Status,
            resource.CreatedAt,
            resource.UpdatedAt);
    }

    public static PatchVehicleCommand ToCommand(int id, PatchVehicleResource resource)
    {
        return new PatchVehicleCommand(
            id,
            resource.FleetId,
            resource.PlateNumber,
            resource.Brand,
            resource.Model,
            resource.Year,
            resource.Vin,
            resource.Status,
            resource.CreatedAt,
            resource.UpdatedAt);
    }

    public static VehicleResource ToResource(Vehicle entity)
    {
        return new VehicleResource(
            entity.Id,
            entity.FleetId,
            entity.PlateNumber,
            entity.Brand,
            entity.Model,
            entity.Year,
            entity.Vin,
            entity.Status,
            entity.CreatedAt,
            entity.UpdatedAt);
    }
}