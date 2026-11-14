using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.InspectionManagement.Domain.Repositories;

public interface IInspectionResultRepository : IBaseRepository<InspectionResult>
{
    Task<IEnumerable<InspectionResult>> ListFilteredAsNoTrackingAsync(int? InspectionId, int? ChecklistItemId,
        CancellationToken cancellationToken = default);
}