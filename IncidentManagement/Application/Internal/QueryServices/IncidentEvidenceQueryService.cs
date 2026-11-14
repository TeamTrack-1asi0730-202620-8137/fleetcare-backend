using Fleet.Care.Platform.IncidentManagement.Application.QueryServices;
using Fleet.Care.Platform.IncidentManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.IncidentManagement.Domain.Model.Queries;
using Fleet.Care.Platform.IncidentManagement.Domain.Repositories;

namespace Fleet.Care.Platform.IncidentManagement.Application.Internal.QueryServices;

public class IncidentEvidenceQueryService(IIncidentEvidenceRepository repository) : IIncidentEvidenceQueryService
{
    public async Task<IEnumerable<IncidentEvidence>> Handle(GetAllIncidentEvidencesQuery query,
        CancellationToken cancellationToken)
    {
        return await repository.ListFilteredAsNoTrackingAsync(query.IncidentId, cancellationToken);
    }

    public async Task<IncidentEvidence?> Handle(GetIncidentEvidenceByIdQuery query, CancellationToken cancellationToken)
    {
        return await repository.FindByIdAsNoTrackingAsync(query.Id, cancellationToken);
    }
}