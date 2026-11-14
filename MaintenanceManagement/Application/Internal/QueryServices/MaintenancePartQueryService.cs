using Fleet.Care.Platform.MaintenanceManagement.Application.QueryServices;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Queries;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Repositories;

namespace Fleet.Care.Platform.MaintenanceManagement.Application.Internal.QueryServices;

public class MaintenancePartQueryService(IMaintenancePartRepository repository) : IMaintenancePartQueryService
{
    public async Task<IEnumerable<MaintenancePart>> Handle(GetAllMaintenancePartsQuery query,
        CancellationToken cancellationToken)
    {
        return await repository.ListFilteredAsNoTrackingAsync(query.MaintenanceRecordId, cancellationToken);
    }

    public async Task<MaintenancePart?> Handle(GetMaintenancePartByIdQuery query, CancellationToken cancellationToken)
    {
        return await repository.FindByIdAsNoTrackingAsync(query.Id, cancellationToken);
    }
}