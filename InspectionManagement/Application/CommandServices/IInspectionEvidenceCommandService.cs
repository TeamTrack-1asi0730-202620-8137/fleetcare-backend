using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Application.Model;

namespace Fleet.Care.Platform.InspectionManagement.Application.CommandServices;

public interface IInspectionEvidenceCommandService
{
    Task<Result<InspectionEvidence>> Handle(CreateInspectionEvidenceCommand command,
        CancellationToken cancellationToken);

    Task<InspectionEvidence?> Handle(UpdateInspectionEvidenceCommand command, CancellationToken cancellationToken);
    Task<InspectionEvidence?> Handle(PatchInspectionEvidenceCommand command, CancellationToken cancellationToken);
}