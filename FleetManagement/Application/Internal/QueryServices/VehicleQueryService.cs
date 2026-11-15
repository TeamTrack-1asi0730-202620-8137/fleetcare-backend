using Fleet.Care.Platform.FleetManagement.Application.QueryServices;
using Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.FleetManagement.Domain.Model.Queries;
using Fleet.Care.Platform.FleetManagement.Domain.Repositories;

namespace Fleet.Care.Platform.FleetManagement.Application.Internal.QueryServices;

public class VehicleQueryService(IVehicleRepository repository) : IVehicleQueryService
{
    public async Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesQuery query, CancellationToken cancellationToken)
    {
        return await repository.ListFilteredAsNoTrackingAsync(query.FleetId, query.PlateNumber, query.Status,
            cancellationToken);
    }

    public async Task<Vehicle?> Handle(GetVehicleByIdQuery query, CancellationToken cancellationToken)
    {
        return await repository.FindByIdAsNoTrackingAsync(query.Id, cancellationToken);
    }
}