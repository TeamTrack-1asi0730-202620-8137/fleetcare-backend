using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.InspectionManagement.Domain.Repositories;

public interface IInspectionEvidenceRepository : IBaseRepository<InspectionEvidence>
{
    Task<IEnumerable<InspectionEvidence>> ListFilteredAsNoTrackingAsync(int? InspectionId,
        CancellationToken cancellationToken = default);
}