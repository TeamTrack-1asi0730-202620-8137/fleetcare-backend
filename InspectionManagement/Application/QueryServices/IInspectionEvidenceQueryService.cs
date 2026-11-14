using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Queries;

namespace Fleet.Care.Platform.InspectionManagement.Application.QueryServices;

public interface IInspectionEvidenceQueryService
{
    Task<IEnumerable<InspectionEvidence>> Handle(GetAllInspectionEvidencesQuery query,
        CancellationToken cancellationToken);

    Task<InspectionEvidence?> Handle(GetInspectionEvidenceByIdQuery query, CancellationToken cancellationToken);
}