using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Queries;

namespace Fleet.Care.Platform.InspectionManagement.Application.QueryServices;

public interface IChecklistItemQueryService
{
    Task<IEnumerable<ChecklistItem>> Handle(GetAllChecklistItemsQuery query, CancellationToken cancellationToken);
    Task<ChecklistItem?> Handle(GetChecklistItemByIdQuery query, CancellationToken cancellationToken);
}