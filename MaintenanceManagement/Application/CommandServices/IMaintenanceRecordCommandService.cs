using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Application.Model;

namespace Fleet.Care.Platform.MaintenanceManagement.Application.CommandServices;

public interface IMaintenanceRecordCommandService
{
    Task<Result<MaintenanceRecord>> Handle(CreateMaintenanceRecordCommand command, CancellationToken cancellationToken);
    Task<MaintenanceRecord?> Handle(UpdateMaintenanceRecordCommand command, CancellationToken cancellationToken);
    Task<MaintenanceRecord?> Handle(PatchMaintenanceRecordCommand command, CancellationToken cancellationToken);
}