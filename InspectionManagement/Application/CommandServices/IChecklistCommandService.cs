using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Application.Model;

namespace Fleet.Care.Platform.InspectionManagement.Application.CommandServices;

public interface IChecklistCommandService
{
    Task<Result<Checklist>> Handle(CreateChecklistCommand command, CancellationToken cancellationToken);
    Task<Checklist?> Handle(UpdateChecklistCommand command, CancellationToken cancellationToken);
    Task<Checklist?> Handle(PatchChecklistCommand command, CancellationToken cancellationToken);
}