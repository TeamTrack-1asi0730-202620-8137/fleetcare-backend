using Fleet.Care.Platform.VehicleOperations.Domain.Model.Aggregates;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Commands;
using Fleet.Care.Platform.VehicleOperations.Interfaces.Rest.Resources;

namespace Fleet.Care.Platform.VehicleOperations.Interfaces.Rest.Transform;

public static class MileageRecordAssemblers
{
    public static CreateMileageRecordCommand ToCommand(CreateMileageRecordResource resource)
    {
        return new CreateMileageRecordCommand(
            resource.VehicleId,
            resource.RegisteredByUserId,
            resource.Mileage,
            resource.RecordedAt,
            resource.CreatedAt);
    }

    public static UpdateMileageRecordCommand ToCommand(int id, UpdateMileageRecordResource resource)
    {
        return new UpdateMileageRecordCommand(
            id,
            resource.VehicleId,
            resource.RegisteredByUserId,
            resource.Mileage,
            resource.RecordedAt,
            resource.CreatedAt);
    }

    public static PatchMileageRecordCommand ToCommand(int id, PatchMileageRecordResource resource)
    {
        return new PatchMileageRecordCommand(
            id,
            resource.VehicleId,
            resource.RegisteredByUserId,
            resource.Mileage,
            resource.RecordedAt,
            resource.CreatedAt);
    }

    public static MileageRecordResource ToResource(MileageRecord entity)
    {
        return new MileageRecordResource(
            entity.Id,
            entity.VehicleId,
            entity.RegisteredByUserId,
            entity.Mileage,
            entity.RecordedAt,
            entity.CreatedAt);
    }
}