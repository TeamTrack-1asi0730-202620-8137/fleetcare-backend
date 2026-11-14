using Fleet.Care.Platform.IncidentManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.IncidentManagement.Domain.Model.Commands;
using Fleet.Care.Platform.IncidentManagement.Interfaces.Rest.Resources;

namespace Fleet.Care.Platform.IncidentManagement.Interfaces.Rest.Transform;

public static class IncidentEvidenceAssemblers
{
    public static CreateIncidentEvidenceCommand ToCommand(CreateIncidentEvidenceResource resource)
    {
        return new CreateIncidentEvidenceCommand(
            resource.IncidentId,
            resource.FileUrl,
            resource.Description,
            resource.CreatedAt);
    }

    public static UpdateIncidentEvidenceCommand ToCommand(int id, UpdateIncidentEvidenceResource resource)
    {
        return new UpdateIncidentEvidenceCommand(
            id,
            resource.IncidentId,
            resource.FileUrl,
            resource.Description,
            resource.CreatedAt);
    }

    public static PatchIncidentEvidenceCommand ToCommand(int id, PatchIncidentEvidenceResource resource)
    {
        return new PatchIncidentEvidenceCommand(
            id,
            resource.IncidentId,
            resource.FileUrl,
            resource.Description,
            resource.CreatedAt);
    }

    public static IncidentEvidenceResource ToResource(IncidentEvidence entity)
    {
        return new IncidentEvidenceResource(
            entity.Id,
            entity.IncidentId,
            entity.FileUrl,
            entity.Description,
            entity.CreatedAt);
    }
}