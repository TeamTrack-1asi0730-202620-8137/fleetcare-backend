using Fleet.Care.Platform.InspectionManagement.Application.QueryServices;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Queries;
using Fleet.Care.Platform.InspectionManagement.Domain.Repositories;

namespace Fleet.Care.Platform.InspectionManagement.Application.Internal.QueryServices;

public class InspectionQueryService(IInspectionRepository repository) : IInspectionQueryService
{
    public async Task<IEnumerable<Inspection>> Handle(GetAllInspectionsQuery query, CancellationToken cancellationToken)
    {
        return await repository.ListFilteredAsNoTrackingAsync(query.VehicleId, query.ChecklistId, query.DriverId,
            query.Status, cancellationToken);
    }

    public async Task<Inspection?> Handle(GetInspectionByIdQuery query, CancellationToken cancellationToken)
    {
        return await repository.FindByIdAsNoTrackingAsync(query.Id, cancellationToken);
    }
}