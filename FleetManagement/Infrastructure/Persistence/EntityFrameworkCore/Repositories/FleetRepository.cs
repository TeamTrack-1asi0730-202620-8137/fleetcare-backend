using Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.FleetManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Care.Platform.FleetManagement.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class FleetRepository(AppDbContext context) : BaseRepository<FleetAggregate>(context), IFleetRepository
{
    public async Task<IEnumerable<FleetAggregate>> ListFilteredAsNoTrackingAsync(CancellationToken cancellationToken = default)
    {
        var query = Context.Set<FleetAggregate>().AsNoTracking().AsQueryable();

        return await query.ToListAsync(cancellationToken);
    }
}