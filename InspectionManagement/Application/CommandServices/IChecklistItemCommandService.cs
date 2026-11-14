using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Application.Model;

namespace Fleet.Care.Platform.InspectionManagement.Application.CommandServices;

public interface IChecklistItemCommandService
{
    Task<Result<ChecklistItem>> Handle(CreateChecklistItemCommand command, CancellationToken cancellationToken);
    Task<ChecklistItem?> Handle(UpdateChecklistItemCommand command, CancellationToken cancellationToken);
    Task<ChecklistItem?> Handle(PatchChecklistItemCommand command, CancellationToken cancellationToken);
}