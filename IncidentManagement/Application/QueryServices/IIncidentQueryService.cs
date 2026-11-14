using Fleet.Care.Platform.IncidentManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.IncidentManagement.Domain.Model.Queries;

namespace Fleet.Care.Platform.IncidentManagement.Application.QueryServices;

public interface IIncidentQueryService
{
    Task<IEnumerable<Incident>> Handle(GetAllIncidentsQuery query, CancellationToken cancellationToken);
    Task<Incident?> Handle(GetIncidentByIdQuery query, CancellationToken cancellationToken);
}