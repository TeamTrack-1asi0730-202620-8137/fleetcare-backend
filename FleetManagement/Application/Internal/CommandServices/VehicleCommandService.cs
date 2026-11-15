using Fleet.Care.Platform.FleetManagement.Application.CommandServices;
using Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.FleetManagement.Domain.Model.Commands;
using Fleet.Care.Platform.FleetManagement.Domain.Repositories;
using Fleet.Care.Platform.Shared.Application.Model;
using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.FleetManagement.Application.Internal.CommandServices;

public class VehicleCommandService(IVehicleRepository repository, IUnitOfWork unitOfWork) : IVehicleCommandService
{
    public async Task<Result<Vehicle>> Handle(CreateVehicleCommand command, CancellationToken cancellationToken)
    {
        var entity = new Vehicle(command);
        await repository.AddAsync(entity, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);
        return Result<Vehicle>.Success(entity);
    }

    public async Task<Vehicle?> Handle(UpdateVehicleCommand command, CancellationToken cancellationToken)
    {
        var entity = await repository.FindByIdAsync(command.Id, cancellationToken);
        if (entity is null) return null;
        entity.Update(command);
        repository.Update(entity);
        await unitOfWork.CompleteAsync(cancellationToken);
        return entity;
    }

    public async Task<Vehicle?> Handle(PatchVehicleCommand command, CancellationToken cancellationToken)
    {
        var entity = await repository.FindByIdAsync(command.Id, cancellationToken);
        if (entity is null) return null;
        entity.Patch(command);
        repository.Update(entity);
        await unitOfWork.CompleteAsync(cancellationToken);
        return entity;
    }
}