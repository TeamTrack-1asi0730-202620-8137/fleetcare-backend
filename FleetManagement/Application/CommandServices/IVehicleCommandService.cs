using Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.FleetManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Application.Model;

namespace Fleet.Care.Platform.FleetManagement.Application.CommandServices;

public interface IVehicleCommandService
{
    Task<Result<Vehicle>> Handle(CreateVehicleCommand command, CancellationToken cancellationToken);
    Task<Vehicle?> Handle(UpdateVehicleCommand command, CancellationToken cancellationToken);
    Task<Vehicle?> Handle(PatchVehicleCommand command, CancellationToken cancellationToken);
}