using Fleet.Care.Platform.InspectionManagement.Application.CommandServices;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;
using Fleet.Care.Platform.InspectionManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Application.Model;
using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.InspectionManagement.Application.Internal.CommandServices;

public class InspectionEvidenceCommandService(IInspectionEvidenceRepository repository, IUnitOfWork unitOfWork)
    : IInspectionEvidenceCommandService
{
    public async Task<Result<InspectionEvidence>> Handle(CreateInspectionEvidenceCommand command,
        CancellationToken cancellationToken)
    {
        var entity = new InspectionEvidence(command);
        await repository.AddAsync(entity, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);
        return Result<InspectionEvidence>.Success(entity);
    }

    public async Task<InspectionEvidence?> Handle(UpdateInspectionEvidenceCommand command,
        CancellationToken cancellationToken)
    {
        var entity = await repository.FindByIdAsync(command.Id, cancellationToken);
        if (entity is null) return null;
        entity.Update(command);
        repository.Update(entity);
        await unitOfWork.CompleteAsync(cancellationToken);
        return entity;
    }

    public async Task<InspectionEvidence?> Handle(PatchInspectionEvidenceCommand command,
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