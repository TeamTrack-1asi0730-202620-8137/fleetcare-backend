using Fleet.Care.Platform.IncidentManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.Shared.Domain.Repositories;

namespace Fleet.Care.Platform.IncidentManagement.Domain.Repositories;

public interface IIncidentRepository : IBaseRepository<Incident>
{
    Task<IEnumerable<Incident>> ListFilteredAsNoTrackingAsync(int? VehicleId, int? ReportedByUserId, string? Status,
        int? SourceInspectionId, CancellationToken cancellationToken = default);
}