using Fleet.Care.Platform.FleetManagement.Application.QueryServices;
using Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.FleetManagement.Domain.Model.Queries;
using Fleet.Care.Platform.FleetManagement.Domain.Repositories;

namespace Fleet.Care.Platform.FleetManagement.Application.Internal.QueryServices;

public class FleetQueryService(IFleetRepository repository) : IFleetQueryService
{
    public async Task<IEnumerable<FleetAggregate>> Handle(GetAllFleetsQuery query, CancellationToken cancellationToken)
    {
        return await repository.ListFilteredAsNoTrackingAsync(cancellationToken);
    }

    public async Task<FleetAggregate?> Handle(GetFleetByIdQuery query, CancellationToken cancellationToken)
    {
        return await repository.FindByIdAsNoTrackingAsync(query.Id, cancellationToken);
    }
}