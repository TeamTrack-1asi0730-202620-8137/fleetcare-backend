using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.InspectionManagement.Domain.Repositories;

public interface IInspectionRepository : IBaseRepository<Inspection>
{
    Task<IEnumerable<Inspection>> ListFilteredAsNoTrackingAsync(int? VehicleId, int? ChecklistId, int? DriverId,
        string? Status, CancellationToken cancellationToken = default);
}