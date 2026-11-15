using Fleet.Care.Platform.MaintenanceManagement.Application.CommandServices;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Commands;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Application.Model;
using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.MaintenanceManagement.Application.Internal.CommandServices;

public class MaintenanceRecordCommandService(IMaintenanceRecordRepository repository, IUnitOfWork unitOfWork)
    : IMaintenanceRecordCommandService
{
    public async Task<Result<MaintenanceRecord>> Handle(CreateMaintenanceRecordCommand command,
        CancellationToken cancellationToken)
    {
        var entity = new MaintenanceRecord(command);
        await repository.AddAsync(entity, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);
        return Result<MaintenanceRecord>.Success(entity);
    }

    public async Task<MaintenanceRecord?> Handle(UpdateMaintenanceRecordCommand command,
        CancellationToken cancellationToken)
    {
        var entity = await repository.FindByIdAsync(command.Id, cancellationToken);
        if (entity is null) return null;
        entity.Update(command);
        repository.Update(entity);
        await unitOfWork.CompleteAsync(cancellationToken);
        return entity;
    }

    public async Task<MaintenanceRecord?> Handle(PatchMaintenanceRecordCommand command,
        CancellationToken cancellationToken)
    {
        var entity = await repository.FindByIdAsync(command.Id, cancellationToken);
        if (entity is null) return null;
        entity.Patch(command);
        repository.Update(entity);
        await unitOfWork.CompleteAsync(cancellationToken);
        return entity;
    }
}