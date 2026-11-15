using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;
using Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Transform;

public static class ChecklistItemAssemblers
{
    public static CreateChecklistItemCommand ToCommand(CreateChecklistItemResource resource)
    {
        return new CreateChecklistItemCommand(
            resource.ChecklistId,
            resource.Description,
            resource.SortOrder,
            resource.IsRequired);
    }

    public static UpdateChecklistItemCommand ToCommand(int id, UpdateChecklistItemResource resource)
    {
        return new UpdateChecklistItemCommand(
            id,
            resource.ChecklistId,
            resource.Description,
            resource.SortOrder,
            resource.IsRequired);
    }

    public static PatchChecklistItemCommand ToCommand(int id, PatchChecklistItemResource resource)
    {
        return new PatchChecklistItemCommand(
            id,
            resource.ChecklistId,
            resource.Description,
            resource.SortOrder,
            resource.IsRequired);
    }

    public static ChecklistItemResource ToResource(ChecklistItem entity)
    {
        return new ChecklistItemResource(
            entity.Id,
            entity.ChecklistId,
            entity.Description,
            entity.SortOrder,
            entity.IsRequired);
    }
}