using Fleet.Care.Platform.Shared.Application.Model;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Aggregates;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Commands;

namespace Fleet.Care.Platform.VehicleOperations.Application.CommandServices;

public interface IFuelRecordCommandService
{
    Task<Result<FuelRecord>> Handle(CreateFuelRecordCommand command, CancellationToken cancellationToken);
    Task<FuelRecord?> Handle(UpdateFuelRecordCommand command, CancellationToken cancellationToken);
    Task<FuelRecord?> Handle(PatchFuelRecordCommand command, CancellationToken cancellationToken);
}