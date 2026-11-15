using Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.FleetManagement.Domain.Model.Queries;

namespace Fleet.Care.Platform.FleetManagement.Application.QueryServices;

public interface IFleetQueryService
{
    Task<IEnumerable<FleetAggregate>> Handle(GetAllFleetsQuery query, CancellationToken cancellationToken);
    Task<FleetAggregate?> Handle(GetFleetByIdQuery query, CancellationToken cancellationToken);
}