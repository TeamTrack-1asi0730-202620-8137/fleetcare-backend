using Fleet.Care.Platform.VehicleOperations.Application.QueryServices;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Aggregates;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Queries;
using Fleet.Care.Platform.VehicleOperations.Domain.Repositories;

namespace Fleet.Care.Platform.VehicleOperations.Application.Internal.QueryServices;

public class MileageRecordQueryService(IMileageRecordRepository repository) : IMileageRecordQueryService
{
    public async Task<IEnumerable<MileageRecord>> Handle(GetAllMileageRecordsQuery query,
        CancellationToken cancellationToken)
    {
        return await repository.ListFilteredAsNoTrackingAsync(query.VehicleId, query.RegisteredByUserId,
            cancellationToken);
    }

    public async Task<MileageRecord?> Handle(GetMileageRecordByIdQuery query, CancellationToken cancellationToken)
    {
        return await repository.FindByIdAsNoTrackingAsync(query.Id, cancellationToken);
    }
}