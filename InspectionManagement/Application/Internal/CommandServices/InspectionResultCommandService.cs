using Fleet.Care.Platform.InspectionManagement.Application.CommandServices;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;
using Fleet.Care.Platform.InspectionManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Application.Model;
using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.InspectionManagement.Application.Internal.CommandServices;

public class InspectionResultCommandService(IInspectionResultRepository repository, IUnitOfWork unitOfWork)
    : IInspectionResultCommandService
{
    public async Task<Result<InspectionResult>> Handle(CreateInspectionResultCommand command,
        CancellationToken cancellationToken)
    {
        var entity = new InspectionResult(command);
        await repository.AddAsync(entity, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);
        return Result<InspectionResult>.Success(entity);
    }

    public async Task<InspectionResult?> Handle(UpdateInspectionResultCommand command,
        CancellationToken cancellationToken)
    {
        var entity = await repository.FindByIdAsync(command.Id, cancellationToken);
        if (entity is null) return null;
        entity.Update(command);
        repository.Update(entity);
        await unitOfWork.CompleteAsync(cancellationToken);
        return entity;
    }

    public async Task<InspectionResult?> Handle(PatchInspectionResultCommand command,
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