using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.MaintenanceManagement.Domain.Repositories;

public interface IMaintenanceRecordRepository : IBaseRepository<MaintenanceRecord>
{
    Task<IEnumerable<MaintenanceRecord>> ListFilteredAsNoTrackingAsync(int? MaintenancePlanId, int? VehicleId,
        string? MaintenanceType, CancellationToken cancellationToken = default);
}