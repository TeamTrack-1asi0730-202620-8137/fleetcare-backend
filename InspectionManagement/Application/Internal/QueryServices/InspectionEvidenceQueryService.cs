using Fleet.Care.Platform.InspectionManagement.Application.QueryServices;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Queries;
using Fleet.Care.Platform.InspectionManagement.Domain.Repositories;

namespace Fleet.Care.Platform.InspectionManagement.Application.Internal.QueryServices;

public class InspectionEvidenceQueryService(IInspectionEvidenceRepository repository) : IInspectionEvidenceQueryService
{
    public async Task<IEnumerable<InspectionEvidence>> Handle(GetAllInspectionEvidencesQuery query,
        CancellationToken cancellationToken)
    {
        return await repository.ListFilteredAsNoTrackingAsync(query.InspectionId, cancellationToken);
    }

    public async Task<InspectionEvidence?> Handle(GetInspectionEvidenceByIdQuery query,
        CancellationToken cancellationToken)
    {
        return await repository.FindByIdAsNoTrackingAsync(query.Id, cancellationToken);
    }
}