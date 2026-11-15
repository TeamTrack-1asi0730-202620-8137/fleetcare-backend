using Fleet.Care.Platform.IncidentManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.IncidentManagement.Domain.Model.Commands;
using Fleet.Care.Platform.IncidentManagement.Interfaces.Rest.Resources;

namespace Fleet.Care.Platform.IncidentManagement.Interfaces.Rest.Transform;

public static class IncidentAssemblers
{
    public static CreateIncidentCommand ToCommand(CreateIncidentResource resource)
    {
        return new CreateIncidentCommand(
            resource.VehicleId,
            resource.ReportedByUserId,
            resource.SourceInspectionId,
            resource.Title,
            resource.Description,
            resource.Status,
            resource.Latitude,
            resource.Longitude,
            resource.Address,
            resource.ReportedAt,
            resource.ResolvedAt,
            resource.Resolution,
            resource.CreatedAt,
            resource.UpdatedAt);
    }

    public static UpdateIncidentCommand ToCommand(int id, UpdateIncidentResource resource)
    {
        return new UpdateIncidentCommand(
            id,
            resource.VehicleId,
            resource.ReportedByUserId,
            resource.SourceInspectionId,
            resource.Title,
            resource.Description,
            resource.Status,
            resource.Latitude,
            resource.Longitude,
            resource.Address,
            resource.ReportedAt,
            resource.ResolvedAt,
            resource.Resolution,
            resource.CreatedAt,
            resource.UpdatedAt);
    }

    public static PatchIncidentCommand ToCommand(int id, PatchIncidentResource resource)
    {
        return new PatchIncidentCommand(
            id,
            resource.VehicleId,
            resource.ReportedByUserId,
            resource.SourceInspectionId,
            resource.Title,
            resource.Description,
            resource.Status,
            resource.Latitude,
            resource.Longitude,
            resource.Address,
            resource.ReportedAt,
            resource.ResolvedAt,
            resource.Resolution,
            resource.CreatedAt,
            resource.UpdatedAt);
    }

    public static IncidentResource ToResource(Incident entity)
    {
        return new IncidentResource(
            entity.Id,
            entity.VehicleId,
            entity.ReportedByUserId,
            entity.SourceInspectionId,
            entity.Title,
            entity.Description,
            entity.Status,
            entity.Latitude,
            entity.Longitude,
            entity.Address,
            entity.ReportedAt,
            entity.ResolvedAt,
            entity.Resolution,
            entity.CreatedAt,
            entity.UpdatedAt);
    }
}