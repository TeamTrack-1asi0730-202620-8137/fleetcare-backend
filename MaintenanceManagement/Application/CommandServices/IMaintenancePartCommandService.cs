using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Application.Model;

namespace Fleet.Care.Platform.MaintenanceManagement.Application.CommandServices;

public interface IMaintenancePartCommandService
{
    Task<Result<MaintenancePart>> Handle(CreateMaintenancePartCommand command, CancellationToken cancellationToken);
    Task<MaintenancePart?> Handle(UpdateMaintenancePartCommand command, CancellationToken cancellationToken);
    Task<MaintenancePart?> Handle(PatchMaintenancePartCommand command, CancellationToken cancellationToken);
}