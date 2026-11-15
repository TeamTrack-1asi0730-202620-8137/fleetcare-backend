using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Queries;

namespace Fleet.Care.Platform.MaintenanceManagement.Application.QueryServices;

public interface IMaintenancePlanQueryService
{
    Task<IEnumerable<MaintenancePlan>> Handle(GetAllMaintenancePlansQuery query, CancellationToken cancellationToken);
    Task<MaintenancePlan?> Handle(GetMaintenancePlanByIdQuery query, CancellationToken cancellationToken);
}