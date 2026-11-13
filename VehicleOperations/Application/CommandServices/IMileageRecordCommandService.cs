using Fleet.Care.Platform.Shared.Application.Model;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Aggregates;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Commands;

namespace Fleet.Care.Platform.VehicleOperations.Application.CommandServices;

public interface IMileageRecordCommandService
{
    Task<Result<MileageRecord>> Handle(CreateMileageRecordCommand command, CancellationToken cancellationToken);
    Task<MileageRecord?> Handle(UpdateMileageRecordCommand command, CancellationToken cancellationToken);
    Task<MileageRecord?> Handle(PatchMileageRecordCommand command, CancellationToken cancellationToken);
}