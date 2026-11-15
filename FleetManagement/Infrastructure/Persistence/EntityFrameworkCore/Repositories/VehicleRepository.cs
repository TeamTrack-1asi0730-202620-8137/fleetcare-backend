using Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.FleetManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Care.Platform.FleetManagement.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class VehicleRepository(AppDbContext context) : BaseRepository<Vehicle>(context), IVehicleRepository
{
    public async Task<IEnumerable<Vehicle>> ListFilteredAsNoTrackingAsync(int? FleetId, string? PlateNumber,
        string? Status, CancellationToken cancellationToken = default)
    {
        var query = Context.Set<Vehicle>().AsNoTracking().AsQueryable();
        if (FleetId.HasValue) query = query.Where(x => x.FleetId == FleetId.Value);
        if (!string.IsNullOrWhiteSpace(PlateNumber)) query = query.Where(x => x.PlateNumber == PlateNumber);
        if (!string.IsNullOrWhiteSpace(Status)) query = query.Where(x => x.Status == Status);
        return await query.ToListAsync(cancellationToken);
    }
}