using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Queries;

namespace Fleet.Care.Platform.InspectionManagement.Application.QueryServices;

public interface IChecklistQueryService
{
    Task<IEnumerable<Checklist>> Handle(GetAllChecklistsQuery query, CancellationToken cancellationToken);
    Task<Checklist?> Handle(GetChecklistByIdQuery query, CancellationToken cancellationToken);
}