using Fleet.Care.Platform.MaintenanceManagement.Application.CommandServices;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Commands;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Application.Model;
using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.MaintenanceManagement.Application.Internal.CommandServices;

public class MaintenancePlanCommandService(IMaintenancePlanRepository repository, IUnitOfWork unitOfWork)
    : IMaintenancePlanCommandService
{
    public async Task<Result<MaintenancePlan>> Handle(CreateMaintenancePlanCommand command,
        CancellationToken cancellationToken)
    {
        var entity = new MaintenancePlan(command);
        await repository.AddAsync(entity, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);
        return Result<MaintenancePlan>.Success(entity);
    }

    public async Task<MaintenancePlan?> Handle(UpdateMaintenancePlanCommand command,
        CancellationToken cancellationToken)
    {
        var entity = await repository.FindByIdAsync(command.Id, cancellationToken);
        if (entity is null) return null;
        entity.Update(command);
        repository.Update(entity);
        await unitOfWork.CompleteAsync(cancellationToken);
        return entity;
    }

    public async Task<MaintenancePlan?> Handle(PatchMaintenancePlanCommand command, CancellationToken cancellationToken)
    {
        var entity = await repository.FindByIdAsync(command.Id, cancellationToken);
        if (entity is null) return null;
        entity.Patch(command);
        repository.Update(entity);
        await unitOfWork.CompleteAsync(cancellationToken);
        return entity;
    }
}