using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;
using Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Transform;

public static class InspectionEvidenceAssemblers
{
    public static CreateInspectionEvidenceCommand ToCommand(CreateInspectionEvidenceResource resource)
    {
        return new CreateInspectionEvidenceCommand(
            resource.InspectionId,
            resource.FileUrl,
            resource.Description,
            resource.CreatedAt);
    }

    public static UpdateInspectionEvidenceCommand ToCommand(int id, UpdateInspectionEvidenceResource resource)
    {
        return new UpdateInspectionEvidenceCommand(
            id,
            resource.InspectionId,
            resource.FileUrl,
            resource.Description,
            resource.CreatedAt);
    }

    public static PatchInspectionEvidenceCommand ToCommand(int id, PatchInspectionEvidenceResource resource)
    {
        return new PatchInspectionEvidenceCommand(
            id,
            resource.InspectionId,
            resource.FileUrl,
            resource.Description,
            resource.CreatedAt);
    }

    public static InspectionEvidenceResource ToResource(InspectionEvidence entity)
    {
        return new InspectionEvidenceResource(
            entity.Id,
            entity.InspectionId,
            entity.FileUrl,
            entity.Description,
            entity.CreatedAt);
    }
}