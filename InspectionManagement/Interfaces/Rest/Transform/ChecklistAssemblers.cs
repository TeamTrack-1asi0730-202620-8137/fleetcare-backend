using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;
using Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Transform;

public static class ChecklistAssemblers
{
    public static CreateChecklistCommand ToCommand(CreateChecklistResource resource)
    {
        return new CreateChecklistCommand(
            resource.Name,
            resource.Description,
            resource.IsActive,
            resource.CreatedAt);
    }

    public static UpdateChecklistCommand ToCommand(int id, UpdateChecklistResource resource)
    {
        return new UpdateChecklistCommand(
            id,
            resource.Name,
            resource.Description,
            resource.IsActive,
            resource.CreatedAt);
    }

    public static PatchChecklistCommand ToCommand(int id, PatchChecklistResource resource)
    {
        return new PatchChecklistCommand(
            id,
            resource.Name,
            resource.Description,
            resource.IsActive,
            resource.CreatedAt);
    }

    public static ChecklistResource ToResource(Checklist entity)
    {
        return new ChecklistResource(
            entity.Id,
            entity.Name,
            entity.Description,
            entity.IsActive,
            entity.CreatedAt);
    }
}