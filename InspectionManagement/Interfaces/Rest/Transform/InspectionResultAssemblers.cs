using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;
using Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;

namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Transform;

public static class InspectionResultAssemblers
{
    public static CreateInspectionResultCommand ToCommand(CreateInspectionResultResource resource)
    {
        return new CreateInspectionResultCommand(
            resource.InspectionId,
            resource.ChecklistItemId,
            resource.Result,
            resource.Observation);
    }

    public static UpdateInspectionResultCommand ToCommand(int id, UpdateInspectionResultResource resource)
    {
        return new UpdateInspectionResultCommand(
            id,
            resource.InspectionId,
            resource.ChecklistItemId,
            resource.Result,
            resource.Observation);
    }

    public static PatchInspectionResultCommand ToCommand(int id, PatchInspectionResultResource resource)
    {
        return new PatchInspectionResultCommand(
            id,
            resource.InspectionId,
            resource.ChecklistItemId,
            resource.Result,
            resource.Observation);
    }

    public static InspectionResultResource ToResource(InspectionResult entity)
    {
        return new InspectionResultResource(
            entity.Id,
            entity.InspectionId,
            entity.ChecklistItemId,
            entity.Result,
            entity.Observation);
    }
}