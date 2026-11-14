using Fleet.Care.Platform.MaintenanceManagement.Application.QueryServices;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Queries;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Repositories;

namespace Fleet.Care.Platform.MaintenanceManagement.Application.Internal.QueryServices;

public class MaintenancePlanQueryService(IMaintenancePlanRepository repository) : IMaintenancePlanQueryService
{
    public async Task<IEnumerable<MaintenancePlan>> Handle(GetAllMaintenancePlansQuery query,
        CancellationToken cancellationToken)
    {
        return await repository.ListFilteredAsNoTrackingAsync(query.VehicleId, query.RelatedIncidentId, query.Status,
            query.MaintenanceType, cancellationToken);
    }

    public async Task<MaintenancePlan?> Handle(GetMaintenancePlanByIdQuery query, CancellationToken cancellationToken)
    {
        return await repository.FindByIdAsNoTrackingAsync(query.Id, cancellationToken);
    }
}