using Fleet.Care.Platform.IncidentManagement.Application.QueryServices;
using Fleet.Care.Platform.IncidentManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.IncidentManagement.Domain.Model.Queries;
using Fleet.Care.Platform.IncidentManagement.Domain.Repositories;

namespace Fleet.Care.Platform.IncidentManagement.Application.Internal.QueryServices;

public class IncidentQueryService(IIncidentRepository repository) : IIncidentQueryService
{
    public async Task<IEnumerable<Incident>> Handle(GetAllIncidentsQuery query, CancellationToken cancellationToken)
    {
        return await repository.ListFilteredAsNoTrackingAsync(query.VehicleId, query.ReportedByUserId, query.Status,
            query.SourceInspectionId, cancellationToken);
    }

    public async Task<Incident?> Handle(GetIncidentByIdQuery query, CancellationToken cancellationToken)
    {
        return await repository.FindByIdAsNoTrackingAsync(query.Id, cancellationToken);
    }
}