using Fleet.Care.Platform.Shared.Application.Model;
using Fleet.Care.Platform.Shared.Domain.Repositories;
using Fleet.Care.Platform.VehicleOperations.Application.CommandServices;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Aggregates;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Commands;
using Fleet.Care.Platform.VehicleOperations.Domain.Repositories;

namespace Fleet.Care.Platform.VehicleOperations.Application.Internal.CommandServices;

public class FuelRecordCommandService(IFuelRecordRepository repository, IUnitOfWork unitOfWork)
    : IFuelRecordCommandService
{
    public async Task<Result<FuelRecord>> Handle(CreateFuelRecordCommand command, CancellationToken cancellationToken)
    {
        var entity = new FuelRecord(command);
        await repository.AddAsync(entity, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);
        return Result<FuelRecord>.Success(entity);
    }

    public async Task<FuelRecord?> Handle(UpdateFuelRecordCommand command, CancellationToken cancellationToken)
    {
        var entity = await repository.FindByIdAsync(command.Id, cancellationToken);
        if (entity is null) return null;
        entity.Update(command);
        repository.Update(entity);
        await unitOfWork.CompleteAsync(cancellationToken);
        return entity;
    }

    public async Task<FuelRecord?> Handle(PatchFuelRecordCommand command, CancellationToken cancellationToken)
    {
        var entity = await repository.FindByIdAsync(command.Id, cancellationToken);
        if (entity is null) return null;
        entity.Patch(command);
        repository.Update(entity);
        await unitOfWork.CompleteAsync(cancellationToken);
        return entity;
    }
}