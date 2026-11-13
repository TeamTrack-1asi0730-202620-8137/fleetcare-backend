using Fleet.Care.Platform.VehicleOperations.Application.QueryServices;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Aggregates;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Queries;
using Fleet.Care.Platform.VehicleOperations.Domain.Repositories;

namespace Fleet.Care.Platform.VehicleOperations.Application.Internal.QueryServices;

public class FuelRecordQueryService(IFuelRecordRepository repository) : IFuelRecordQueryService
{
    public async Task<IEnumerable<FuelRecord>> Handle(GetAllFuelRecordsQuery query, CancellationToken cancellationToken)
    {
        return await repository.ListFilteredAsNoTrackingAsync(query.VehicleId, query.RegisteredByUserId,
            cancellationToken);
    }

    public async Task<FuelRecord?> Handle(GetFuelRecordByIdQuery query, CancellationToken cancellationToken)
    {
        return await repository.FindByIdAsNoTrackingAsync(query.Id, cancellationToken);
    }
}