using Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.FleetManagement.Domain.Repositories;

public interface IVehicleRepository : IBaseRepository<Vehicle>
{
    Task<IEnumerable<Vehicle>> ListFilteredAsNoTrackingAsync(int? FleetId, string? PlateNumber, string? Status,
        CancellationToken cancellationToken = default);
}