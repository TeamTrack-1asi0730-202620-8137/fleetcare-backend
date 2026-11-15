using Fleet.Care.Platform.InspectionManagement.Application.QueryServices;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Queries;
using Fleet.Care.Platform.InspectionManagement.Domain.Repositories;

namespace Fleet.Care.Platform.InspectionManagement.Application.Internal.QueryServices;

public class ChecklistQueryService(IChecklistRepository repository) : IChecklistQueryService
{
    public async Task<IEnumerable<Checklist>> Handle(GetAllChecklistsQuery query, CancellationToken cancellationToken)
    {
        return await repository.ListFilteredAsNoTrackingAsync(query.IsActive, cancellationToken);
    }

    public async Task<Checklist?> Handle(GetChecklistByIdQuery query, CancellationToken cancellationToken)
    {
        return await repository.FindByIdAsNoTrackingAsync(query.Id, cancellationToken);
    }
}