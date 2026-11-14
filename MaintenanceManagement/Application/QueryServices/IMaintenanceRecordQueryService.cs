using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Queries;

namespace Fleet.Care.Platform.MaintenanceManagement.Application.QueryServices;

public interface IMaintenanceRecordQueryService
{
    Task<IEnumerable<MaintenanceRecord>> Handle(GetAllMaintenanceRecordsQuery query,
        CancellationToken cancellationToken);

    Task<MaintenanceRecord?> Handle(GetMaintenanceRecordByIdQuery query, CancellationToken cancellationToken);
}