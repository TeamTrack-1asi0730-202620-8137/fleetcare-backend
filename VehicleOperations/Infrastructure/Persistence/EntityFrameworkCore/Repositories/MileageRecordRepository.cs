using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Aggregates;
using Fleet.Care.Platform.VehicleOperations.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Care.Platform.VehicleOperations.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class MileageRecordRepository(AppDbContext context)
    : BaseRepository<MileageRecord>(context), IMileageRecordRepository
{
    public async Task<IEnumerable<MileageRecord>> ListFilteredAsNoTrackingAsync(int? VehicleId, int? RegisteredByUserId,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<MileageRecord>().AsNoTracking().AsQueryable();
        if (VehicleId.HasValue) query = query.Where(x => x.VehicleId == VehicleId.Value);
        if (RegisteredByUserId.HasValue) query = query.Where(x => x.RegisteredByUserId == RegisteredByUserId.Value);
        return await query.ToListAsync(cancellationToken);
    }
}