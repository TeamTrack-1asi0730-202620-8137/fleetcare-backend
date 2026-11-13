using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Care.Platform.MaintenanceManagement.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class MaintenancePlanRepository(AppDbContext context)
    : BaseRepository<MaintenancePlan>(context), IMaintenancePlanRepository
{
    public async Task<IEnumerable<MaintenancePlan>> ListFilteredAsNoTrackingAsync(int? VehicleId,
        int? RelatedIncidentId, string? Status, string? MaintenanceType, CancellationToken cancellationToken = default)
    {
        var query = Context.Set<MaintenancePlan>().AsNoTracking().AsQueryable();
        if (VehicleId.HasValue) query = query.Where(x => x.VehicleId == VehicleId.Value);
        if (RelatedIncidentId.HasValue) query = query.Where(x => x.RelatedIncidentId == RelatedIncidentId.Value);
        if (!string.IsNullOrWhiteSpace(Status)) query = query.Where(x => x.Status == Status);
        if (!string.IsNullOrWhiteSpace(MaintenanceType)) query = query.Where(x => x.MaintenanceType == MaintenanceType);
        return await query.ToListAsync(cancellationToken);
    }
}