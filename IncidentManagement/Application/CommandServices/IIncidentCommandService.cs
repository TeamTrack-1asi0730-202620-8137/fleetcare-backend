using Fleet.Care.Platform.IncidentManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.IncidentManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Application.Model;

namespace Fleet.Care.Platform.IncidentManagement.Application.CommandServices;

public interface IIncidentCommandService
{
    Task<Result<Incident>> Handle(CreateIncidentCommand command, CancellationToken cancellationToken);
    Task<Incident?> Handle(UpdateIncidentCommand command, CancellationToken cancellationToken);
    Task<Incident?> Handle(PatchIncidentCommand command, CancellationToken cancellationToken);
}