using Fleet.Care.Platform.InspectionManagement.Application.CommandServices;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;
using Fleet.Care.Platform.InspectionManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Application.Model;
using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.InspectionManagement.Application.Internal.CommandServices;

public class ChecklistItemCommandService(IChecklistItemRepository repository, IUnitOfWork unitOfWork)
    : IChecklistItemCommandService
{
    public async Task<Result<ChecklistItem>> Handle(CreateChecklistItemCommand command,
        CancellationToken cancellationToken)
    {
        var entity = new ChecklistItem(command);
        await repository.AddAsync(entity, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);
        return Result<ChecklistItem>.Success(entity);
    }

    public async Task<ChecklistItem?> Handle(UpdateChecklistItemCommand command, CancellationToken cancellationToken)
    {
        var entity = await repository.FindByIdAsync(command.Id, cancellationToken);
        if (entity is null) return null;
        entity.Update(command);
        repository.Update(entity);
        await unitOfWork.CompleteAsync(cancellationToken);
        return entity;
    }

    public async Task<ChecklistItem?> Handle(PatchChecklistItemCommand command, CancellationToken cancellationToken)
    {
        var entity = await repository.FindByIdAsync(command.Id, cancellationToken);
        if (entity is null) return null;
        entity.Patch(command);
        repository.Update(entity);
        await unitOfWork.CompleteAsync(cancellationToken);
        return entity;
    }
}