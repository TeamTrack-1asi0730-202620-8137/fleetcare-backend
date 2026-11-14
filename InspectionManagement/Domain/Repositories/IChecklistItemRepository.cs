using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.InspectionManagement.Domain.Repositories;

public interface IChecklistItemRepository : IBaseRepository<ChecklistItem>
{
    Task<IEnumerable<ChecklistItem>> ListFilteredAsNoTrackingAsync(int? ChecklistId,
        CancellationToken cancellationToken = default);
}