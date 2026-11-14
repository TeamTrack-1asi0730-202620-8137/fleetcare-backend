using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Queries;

namespace Fleet.Care.Platform.InspectionManagement.Application.QueryServices;

public interface IInspectionQueryService
{
    Task<IEnumerable<Inspection>> Handle(GetAllInspectionsQuery query, CancellationToken cancellationToken);
    Task<Inspection?> Handle(GetInspectionByIdQuery query, CancellationToken cancellationToken);
}