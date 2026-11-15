using Fleet.Care.Platform.FleetManagement.Application.CommandServices;
using Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.FleetManagement.Domain.Model.Commands;
using Fleet.Care.Platform.FleetManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Application.Model;
using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.FleetManagement.Application.Internal.CommandServices;

public class FleetCommandService(IFleetRepository repository, IUnitOfWork unitOfWork) : IFleetCommandService
{
    public async Task<Result<FleetAggregate>> Handle(CreateFleetCommand command, CancellationToken cancellationToken)
    {
        var entity = new FleetAggregate(command);
        await repository.AddAsync(entity, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);
        return Result<FleetAggregate>.Success(entity);
    }

    public async Task<FleetAggregate?> Handle(UpdateFleetCommand command, CancellationToken cancellationToken)
    {
        var entity = await repository.FindByIdAsync(command.Id, cancellationToken);
        if (entity is null) return null;
        entity.Update(command);
        repository.Update(entity);
        await unitOfWork.CompleteAsync(cancellationToken);
        return entity;
    }

    public async Task<FleetAggregate?> Handle(PatchFleetCommand command, CancellationToken cancellationToken)
    {
        var entity = await repository.FindByIdAsync(command.Id, cancellationToken);
        if (entity is null) return null;
        entity.Patch(command);
        repository.Update(entity);
        await unitOfWork.CompleteAsync(cancellationToken);
        return entity;
    }
}