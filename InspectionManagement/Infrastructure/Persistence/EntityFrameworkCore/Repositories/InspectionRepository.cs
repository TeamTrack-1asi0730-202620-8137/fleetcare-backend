using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Care.Platform.InspectionManagement.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class InspectionRepository(AppDbContext context) : BaseRepository<Inspection>(context), IInspectionRepository
{
    public async Task<IEnumerable<Inspection>> ListFilteredAsNoTrackingAsync(int? VehicleId, int? ChecklistId,
        int? DriverId, string? Status, CancellationToken cancellationToken = default)
    {
        var query = Context.Set<Inspection>().AsNoTracking().AsQueryable();
        if (VehicleId.HasValue) query = query.Where(x => x.VehicleId == VehicleId.Value);
        if (ChecklistId.HasValue) query = query.Where(x => x.ChecklistId == ChecklistId.Value);
        if (DriverId.HasValue) query = query.Where(x => x.DriverId == DriverId.Value);
        if (!string.IsNullOrWhiteSpace(Status)) query = query.Where(x => x.Status == Status);
        return await query.ToListAsync(cancellationToken);
    }
}