using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Queries;

namespace Fleet.Care.Platform.MaintenanceManagement.Application.QueryServices;

public interface IMaintenancePartQueryService
{
    Task<IEnumerable<MaintenancePart>> Handle(GetAllMaintenancePartsQuery query, CancellationToken cancellationToken);
    Task<MaintenancePart?> Handle(GetMaintenancePartByIdQuery query, CancellationToken cancellationToken);
}