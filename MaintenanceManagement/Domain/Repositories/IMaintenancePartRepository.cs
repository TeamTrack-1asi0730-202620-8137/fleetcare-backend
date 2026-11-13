using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.MaintenanceManagement.Domain.Repositories;

public interface IMaintenancePartRepository : IBaseRepository<MaintenancePart>
{
    Task<IEnumerable<MaintenancePart>> ListFilteredAsNoTrackingAsync(int? MaintenanceRecordId,
        CancellationToken cancellationToken = default);
}