using Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.FleetManagement.Domain.Model.Queries;

namespace Fleet.Care.Platform.FleetManagement.Application.QueryServices;

public interface IVehicleQueryService
{
    Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesQuery query, CancellationToken cancellationToken);
    Task<Vehicle?> Handle(GetVehicleByIdQuery query, CancellationToken cancellationToken);
}