using Fleet.Care.Platform.IncidentManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.IncidentManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Care.Platform.IncidentManagement.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class IncidentEvidenceRepository(AppDbContext context)
    : BaseRepository<IncidentEvidence>(context), IIncidentEvidenceRepository
{
    public async Task<IEnumerable<IncidentEvidence>> ListFilteredAsNoTrackingAsync(int? IncidentId,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<IncidentEvidence>().AsNoTracking().AsQueryable();
        if (IncidentId.HasValue) query = query.Where(x => x.IncidentId == IncidentId.Value);
        return await query.ToListAsync(cancellationToken);
    }
}