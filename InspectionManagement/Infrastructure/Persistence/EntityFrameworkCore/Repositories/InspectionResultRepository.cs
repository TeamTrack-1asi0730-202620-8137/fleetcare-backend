using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Care.Platform.InspectionManagement.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class InspectionResultRepository(AppDbContext context)
    : BaseRepository<InspectionResult>(context), IInspectionResultRepository
{
    public async Task<IEnumerable<InspectionResult>> ListFilteredAsNoTrackingAsync(int? InspectionId,
        int? ChecklistItemId, CancellationToken cancellationToken = default)
    {
        var query = Context.Set<InspectionResult>().AsNoTracking().AsQueryable();
        if (InspectionId.HasValue) query = query.Where(x => x.InspectionId == InspectionId.Value);
        if (ChecklistItemId.HasValue) query = query.Where(x => x.ChecklistItemId == ChecklistItemId.Value);
        return await query.ToListAsync(cancellationToken);
    }
}