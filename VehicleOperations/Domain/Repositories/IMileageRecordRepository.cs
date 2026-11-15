using Fleet.Care.Platform.Shared.Domain.Repositories;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Aggregates;

namespace Fleet.Care.Platform.VehicleOperations.Domain.Repositories;

public interface IMileageRecordRepository : IBaseRepository<MileageRecord>
{
    Task<IEnumerable<MileageRecord>> ListFilteredAsNoTrackingAsync(int? VehicleId, int? RegisteredByUserId,
        CancellationToken cancellationToken = default);
}