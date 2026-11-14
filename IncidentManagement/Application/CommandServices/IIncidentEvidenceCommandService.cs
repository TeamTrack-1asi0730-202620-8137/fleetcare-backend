using Fleet.Care.Platform.IncidentManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.IncidentManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Application.Model;

namespace Fleet.Care.Platform.IncidentManagement.Application.CommandServices;

public interface IIncidentEvidenceCommandService
{
    Task<Result<IncidentEvidence>> Handle(CreateIncidentEvidenceCommand command, CancellationToken cancellationToken);
    Task<IncidentEvidence?> Handle(UpdateIncidentEvidenceCommand command, CancellationToken cancellationToken);
    Task<IncidentEvidence?> Handle(PatchIncidentEvidenceCommand command, CancellationToken cancellationToken);
}