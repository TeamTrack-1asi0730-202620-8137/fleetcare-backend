using Fleet.Care.Platform.InspectionManagement.Application.QueryServices;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Queries;
using Fleet.Care.Platform.InspectionManagement.Domain.Repositories;

namespace Fleet.Care.Platform.InspectionManagement.Application.Internal.QueryServices;

public class ChecklistItemQueryService(IChecklistItemRepository repository) : IChecklistItemQueryService
{
    public async Task<IEnumerable<ChecklistItem>> Handle(GetAllChecklistItemsQuery query,
        CancellationToken cancellationToken)
    {
        return await repository.ListFilteredAsNoTrackingAsync(query.ChecklistId, cancellationToken);
    }

    public async Task<ChecklistItem?> Handle(GetChecklistItemByIdQuery query, CancellationToken cancellationToken)
    {
        return await repository.FindByIdAsNoTrackingAsync(query.Id, cancellationToken);
    }
}