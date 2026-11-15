using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Care.Platform.MaintenanceManagement.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class MaintenanceRecordRepository(AppDbContext context)
    : BaseRepository<MaintenanceRecord>(context), IMaintenanceRecordRepository
{
    public async Task<IEnumerable<MaintenanceRecord>> ListFilteredAsNoTrackingAsync(int? MaintenancePlanId,
        int? VehicleId, string? MaintenanceType, CancellationToken cancellationToken = default)
    {
        var query = Context.Set<MaintenanceRecord>().AsNoTracking().AsQueryable();
        if (MaintenancePlanId.HasValue) query = query.Where(x => x.MaintenancePlanId == MaintenancePlanId.Value);
        if (VehicleId.HasValue) query = query.Where(x => x.VehicleId == VehicleId.Value);
        if (!string.IsNullOrWhiteSpace(MaintenanceType)) query = query.Where(x => x.MaintenanceType == MaintenanceType);
        return await query.ToListAsync(cancellationToken);
    }
}