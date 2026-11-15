using Fleet.Care.Platform.IncidentManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.IncidentManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Care.Platform.IncidentManagement.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class IncidentRepository(AppDbContext context) : BaseRepository<Incident>(context), IIncidentRepository
{
    public async Task<IEnumerable<Incident>> ListFilteredAsNoTrackingAsync(int? VehicleId, int? ReportedByUserId,
        string? Status, int? SourceInspectionId, CancellationToken cancellationToken = default)
    {
        var query = Context.Set<Incident>().AsNoTracking().AsQueryable();
        if (VehicleId.HasValue) query = query.Where(x => x.VehicleId == VehicleId.Value);
        if (ReportedByUserId.HasValue) query = query.Where(x => x.ReportedByUserId == ReportedByUserId.Value);
        if (!string.IsNullOrWhiteSpace(Status)) query = query.Where(x => x.Status == Status);
        if (SourceInspectionId.HasValue) query = query.Where(x => x.SourceInspectionId == SourceInspectionId.Value);
        return await query.ToListAsync(cancellationToken);
    }
}