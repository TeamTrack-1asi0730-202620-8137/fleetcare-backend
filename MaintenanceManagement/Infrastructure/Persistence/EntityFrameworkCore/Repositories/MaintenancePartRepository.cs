using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Care.Platform.MaintenanceManagement.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class MaintenancePartRepository(AppDbContext context)
    : BaseRepository<MaintenancePart>(context), IMaintenancePartRepository
{
    public async Task<IEnumerable<MaintenancePart>> ListFilteredAsNoTrackingAsync(int? MaintenanceRecordId,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<MaintenancePart>().AsNoTracking().AsQueryable();
        if (MaintenanceRecordId.HasValue) query = query.Where(x => x.MaintenanceRecordId == MaintenanceRecordId.Value);
        return await query.ToListAsync(cancellationToken);
    }
}