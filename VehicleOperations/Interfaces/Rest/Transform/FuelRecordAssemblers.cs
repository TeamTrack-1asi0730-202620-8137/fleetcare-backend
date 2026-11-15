using Fleet.Care.Platform.VehicleOperations.Domain.Model.Aggregates;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Commands;
using Fleet.Care.Platform.VehicleOperations.Interfaces.Rest.Resources;

namespace Fleet.Care.Platform.VehicleOperations.Interfaces.Rest.Transform;

public static class FuelRecordAssemblers
{
    public static CreateFuelRecordCommand ToCommand(CreateFuelRecordResource resource)
    {
        return new CreateFuelRecordCommand(
            resource.VehicleId,
            resource.RegisteredByUserId,
            resource.Mileage,
            resource.Liters,
            resource.TotalCost,
            resource.FueledAt,
            resource.CreatedAt);
    }

    public static UpdateFuelRecordCommand ToCommand(int id, UpdateFuelRecordResource resource)
    {
        return new UpdateFuelRecordCommand(
            id,
            resource.VehicleId,
            resource.RegisteredByUserId,
            resource.Mileage,
            resource.Liters,
            resource.TotalCost,
            resource.FueledAt,
            resource.CreatedAt);
    }

    public static PatchFuelRecordCommand ToCommand(int id, PatchFuelRecordResource resource)
    {
        return new PatchFuelRecordCommand(
            id,
            resource.VehicleId,
            resource.RegisteredByUserId,
            resource.Mileage,
            resource.Liters,
            resource.TotalCost,
            resource.FueledAt,
            resource.CreatedAt);
    }

    public static FuelRecordResource ToResource(FuelRecord entity)
    {
        return new FuelRecordResource(
            entity.Id,
            entity.VehicleId,
            entity.RegisteredByUserId,
            entity.Mileage,
            entity.Liters,
            entity.TotalCost,
            entity.FueledAt,
            entity.CreatedAt);
    }
}