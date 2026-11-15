using Fleet.Care.Platform.IncidentManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.IncidentManagement.Domain.Repositories;

public interface IIncidentEvidenceRepository : IBaseRepository<IncidentEvidence>
{
    Task<IEnumerable<IncidentEvidence>> ListFilteredAsNoTrackingAsync(int? IncidentId,
        CancellationToken cancellationToken = default);
}