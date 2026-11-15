using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Care.Platform.InspectionManagement.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class InspectionEvidenceRepository(AppDbContext context)
    : BaseRepository<InspectionEvidence>(context), IInspectionEvidenceRepository
{
    public async Task<IEnumerable<InspectionEvidence>> ListFilteredAsNoTrackingAsync(int? InspectionId,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<InspectionEvidence>().AsNoTracking().AsQueryable();
        if (InspectionId.HasValue) query = query.Where(x => x.InspectionId == InspectionId.Value);
        return await query.ToListAsync(cancellationToken);
    }
}