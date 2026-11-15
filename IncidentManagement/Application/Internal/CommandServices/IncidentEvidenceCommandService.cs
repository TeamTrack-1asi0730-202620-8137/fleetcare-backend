using Fleet.Care.Platform.IncidentManagement.Application.CommandServices;
using Fleet.Care.Platform.IncidentManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.IncidentManagement.Domain.Model.Commands;
using Fleet.Care.Platform.IncidentManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Application.Model;
using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.IncidentManagement.Application.Internal.CommandServices;

public class IncidentEvidenceCommandService(IIncidentEvidenceRepository repository, IUnitOfWork unitOfWork)
    : IIncidentEvidenceCommandService
{
    public async Task<Result<IncidentEvidence>> Handle(CreateIncidentEvidenceCommand command,
        CancellationToken cancellationToken)
    {
        var entity = new IncidentEvidence(command);
        await repository.AddAsync(entity, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);
        return Result<IncidentEvidence>.Success(entity);
    }

    public async Task<IncidentEvidence?> Handle(UpdateIncidentEvidenceCommand command,
        CancellationToken cancellationToken)
    {
        var entity = await repository.FindByIdAsync(command.Id, cancellationToken);
        if (entity is null) return null;
        entity.Update(command);
        repository.Update(entity);
        await unitOfWork.CompleteAsync(cancellationToken);
        return entity;
    }

    public async Task<IncidentEvidence?> Handle(PatchIncidentEvidenceCommand command,
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