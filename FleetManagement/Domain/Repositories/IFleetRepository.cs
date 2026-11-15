using Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;

using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.FleetManagement.Domain.Repositories;

public interface IFleetRepository : IBaseRepository<FleetAggregate>
{
    Task<IEnumerable<FleetAggregate>> ListFilteredAsNoTrackingAsync(CancellationToken cancellationToken = default);
}