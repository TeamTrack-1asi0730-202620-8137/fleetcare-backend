using Fleet.Care.Platform.VehicleOperations.Domain.Model.Aggregates;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Queries;

namespace Fleet.Care.Platform.VehicleOperations.Application.QueryServices;

public interface IFuelRecordQueryService
{
    Task<IEnumerable<FuelRecord>> Handle(GetAllFuelRecordsQuery query, CancellationToken cancellationToken);
    Task<FuelRecord?> Handle(GetFuelRecordByIdQuery query, CancellationToken cancellationToken);
}