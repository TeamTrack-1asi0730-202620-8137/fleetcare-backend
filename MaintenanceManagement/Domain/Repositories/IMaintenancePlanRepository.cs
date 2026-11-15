using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.MaintenanceManagement.Domain.Repositories;

public interface IMaintenancePlanRepository : IBaseRepository<MaintenancePlan>
{
    Task<IEnumerable<MaintenancePlan>> ListFilteredAsNoTrackingAsync(int? VehicleId, int? RelatedIncidentId,
        string? Status, string? MaintenanceType, CancellationToken cancellationToken = default);
}