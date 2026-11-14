using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Application.Model;

namespace Fleet.Care.Platform.InspectionManagement.Application.CommandServices;

public interface IInspectionCommandService
{
    Task<Result<Inspection>> Handle(CreateInspectionCommand command, CancellationToken cancellationToken);
    Task<Inspection?> Handle(UpdateInspectionCommand command, CancellationToken cancellationToken);
    Task<Inspection?> Handle(PatchInspectionCommand command, CancellationToken cancellationToken);
}