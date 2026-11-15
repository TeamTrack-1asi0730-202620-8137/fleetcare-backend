using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Care.Platform.InspectionManagement.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class ChecklistItemRepository(AppDbContext context)
    : BaseRepository<ChecklistItem>(context), IChecklistItemRepository
{
    public async Task<IEnumerable<ChecklistItem>> ListFilteredAsNoTrackingAsync(int? ChecklistId,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<ChecklistItem>().AsNoTracking().AsQueryable();
        if (ChecklistId.HasValue) query = query.Where(x => x.ChecklistId == ChecklistId.Value);
        return await query.ToListAsync(cancellationToken);
    }
}