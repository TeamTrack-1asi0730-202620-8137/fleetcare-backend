using Fleet.Care.Platform.VehicleOperations.Domain.Model.Aggregates;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Queries;

namespace Fleet.Care.Platform.VehicleOperations.Application.QueryServices;

public interface IMileageRecordQueryService
{
    Task<IEnumerable<MileageRecord>> Handle(GetAllMileageRecordsQuery query, CancellationToken cancellationToken);
    Task<MileageRecord?> Handle(GetMileageRecordByIdQuery query, CancellationToken cancellationToken);
}