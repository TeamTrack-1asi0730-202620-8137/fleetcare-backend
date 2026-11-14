using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Application.Model;

namespace Fleet.Care.Platform.InspectionManagement.Application.CommandServices;

public interface IInspectionResultCommandService
{
    Task<Result<InspectionResult>> Handle(CreateInspectionResultCommand command, CancellationToken cancellationToken);
    Task<InspectionResult?> Handle(UpdateInspectionResultCommand command, CancellationToken cancellationToken);
    Task<InspectionResult?> Handle(PatchInspectionResultCommand command, CancellationToken cancellationToken);
}