using Fleet.Care.Platform.MaintenanceManagement.Application.QueryServices;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Queries;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Repositories;

namespace Fleet.Care.Platform.MaintenanceManagement.Application.Internal.QueryServices;

public class MaintenanceRecordQueryService(IMaintenanceRecordRepository repository) : IMaintenanceRecordQueryService
{
    public async Task<IEnumerable<MaintenanceRecord>> Handle(GetAllMaintenanceRecordsQuery query,
        CancellationToken cancellationToken)
    {
        return await repository.ListFilteredAsNoTrackingAsync(query.MaintenancePlanId, query.VehicleId,
            query.MaintenanceType, cancellationToken);
    }

    public async Task<MaintenanceRecord?> Handle(GetMaintenanceRecordByIdQuery query,
        CancellationToken cancellationToken)
    {
        return await repository.FindByIdAsNoTrackingAsync(query.Id, cancellationToken);
    }
}