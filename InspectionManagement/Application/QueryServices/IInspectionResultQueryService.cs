using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Queries;

namespace Fleet.Care.Platform.InspectionManagement.Application.QueryServices;

public interface IInspectionResultQueryService
{
    Task<IEnumerable<InspectionResult>> Handle(GetAllInspectionResultsQuery query, CancellationToken cancellationToken);
    Task<InspectionResult?> Handle(GetInspectionResultByIdQuery query, CancellationToken cancellationToken);
}