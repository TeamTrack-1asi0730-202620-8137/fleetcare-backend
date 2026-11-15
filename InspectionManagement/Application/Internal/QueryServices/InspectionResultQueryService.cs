using Fleet.Care.Platform.InspectionManagement.Application.QueryServices;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Queries;
using Fleet.Care.Platform.InspectionManagement.Domain.Repositories;

namespace Fleet.Care.Platform.InspectionManagement.Application.Internal.QueryServices;

public class InspectionResultQueryService(IInspectionResultRepository repository) : IInspectionResultQueryService
{
    public async Task<IEnumerable<InspectionResult>> Handle(GetAllInspectionResultsQuery query,
        CancellationToken cancellationToken)
    {
        return await repository.ListFilteredAsNoTrackingAsync(query.InspectionId, query.ChecklistItemId,
            cancellationToken);
    }

    public async Task<InspectionResult?> Handle(GetInspectionResultByIdQuery query, CancellationToken cancellationToken)
    {
        return await repository.FindByIdAsNoTrackingAsync(query.Id, cancellationToken);
    }
}