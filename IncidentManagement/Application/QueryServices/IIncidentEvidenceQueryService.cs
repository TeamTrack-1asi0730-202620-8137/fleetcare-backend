using Fleet.Care.Platform.IncidentManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.IncidentManagement.Domain.Model.Queries;

namespace Fleet.Care.Platform.IncidentManagement.Application.QueryServices;

public interface IIncidentEvidenceQueryService
{
    Task<IEnumerable<IncidentEvidence>> Handle(GetAllIncidentEvidencesQuery query, CancellationToken cancellationToken);
    Task<IncidentEvidence?> Handle(GetIncidentEvidenceByIdQuery query, CancellationToken cancellationToken);
}