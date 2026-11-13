using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Aggregates;
using Fleet.Care.Platform.VehicleOperations.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Care.Platform.VehicleOperations.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class FuelRecordRepository(AppDbContext context) : BaseRepository<FuelRecord>(context), IFuelRecordRepository
{
    public async Task<IEnumerable<FuelRecord>> ListFilteredAsNoTrackingAsync(int? VehicleId, int? RegisteredByUserId,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<FuelRecord>().AsNoTracking().AsQueryable();
        if (VehicleId.HasValue) query = query.Where(x => x.VehicleId == VehicleId.Value);
        if (RegisteredByUserId.HasValue) query = query.Where(x => x.RegisteredByUserId == RegisteredByUserId.Value);
        return await query.ToListAsync(cancellationToken);
    }
}