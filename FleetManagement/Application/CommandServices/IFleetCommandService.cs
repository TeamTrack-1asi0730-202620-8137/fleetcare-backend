using Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.FleetManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Application.Model;

namespace Fleet.Care.Platform.FleetManagement.Application.CommandServices;

public interface IFleetCommandService
{
    Task<Result<FleetAggregate>> Handle(CreateFleetCommand command, CancellationToken cancellationToken);
    Task<FleetAggregate?> Handle(UpdateFleetCommand command, CancellationToken cancellationToken);
    Task<FleetAggregate?> Handle(PatchFleetCommand command, CancellationToken cancellationToken);
}