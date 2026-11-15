using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.InspectionManagement.Domain.Repositories;

public interface IChecklistRepository : IBaseRepository<Checklist>
{
    Task<IEnumerable<Checklist>> ListFilteredAsNoTrackingAsync(bool? IsActive,
        CancellationToken cancellationToken = default);
}