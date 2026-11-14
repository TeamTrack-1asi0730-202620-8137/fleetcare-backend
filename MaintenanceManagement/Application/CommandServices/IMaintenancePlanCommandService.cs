using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Application.Model;

namespace Fleet.Care.Platform.MaintenanceManagement.Application.CommandServices;

public interface IMaintenancePlanCommandService
{
    Task<Result<MaintenancePlan>> Handle(CreateMaintenancePlanCommand command, CancellationToken cancellationToken);
    Task<MaintenancePlan?> Handle(UpdateMaintenancePlanCommand command, CancellationToken cancellationToken);
    Task<MaintenancePlan?> Handle(PatchMaintenancePlanCommand command, CancellationToken cancellationToken);
}