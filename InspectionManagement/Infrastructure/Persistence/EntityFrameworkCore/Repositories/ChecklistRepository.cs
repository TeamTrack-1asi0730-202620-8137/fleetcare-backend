using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Care.Platform.InspectionManagement.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class ChecklistRepository(AppDbContext context) : BaseRepository<Checklist>(context), IChecklistRepository
{
    public async Task<IEnumerable<Checklist>> ListFilteredAsNoTrackingAsync(bool? IsActive,
        CancellationToken cancellationToken = default)
    {
        var query = Context.Set<Checklist>().AsNoTracking().AsQueryable();
        if (IsActive.HasValue) query = query.Where(x => x.IsActive == IsActive.Value);
        return await query.ToListAsync(cancellationToken);
    }
}