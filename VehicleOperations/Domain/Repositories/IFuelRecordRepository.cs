using Fleet.Care.Platform.Shared.Domain.Repositories;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Aggregates;

namespace Fleet.Care.Platform.VehicleOperations.Domain.Repositories;

public interface IFuelRecordRepository : IBaseRepository<FuelRecord>
{
    Task<IEnumerable<FuelRecord>> ListFilteredAsNoTrackingAsync(int? VehicleId, int? RegisteredByUserId,
        CancellationToken cancellationToken = default);
}