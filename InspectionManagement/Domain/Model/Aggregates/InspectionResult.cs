using Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Domain.Model.Aggregates.Internal;

namespace Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;

public class InspectionResult : AggregateRoot
{
    protected InspectionResult()
    {
    }

    public InspectionResult(CreateInspectionResultCommand command)
    {
        InspectionId = command.InspectionId;
        ChecklistItemId = command.ChecklistItemId;
        Result = command.Result;
        Observation = command.Observation;
    }

    public int Id { get; private set; }
    public int InspectionId { get; private set; }
    public int ChecklistItemId { get; private set; }
    public string Result { get; private set; } = string.Empty;
    public string? Observation { get; private set; }

    public void Update(UpdateInspectionResultCommand command)
    {
        InspectionId = command.InspectionId;
        ChecklistItemId = command.ChecklistItemId;
        Result = command.Result;
        Observation = command.Observation;
    }

    public void Patch(PatchInspectionResultCommand command)
    {
        if (command.InspectionId is not null) InspectionId = command.InspectionId.Value;
        if (command.ChecklistItemId is not null) ChecklistItemId = command.ChecklistItemId.Value;
        if (command.Result is not null) Result = command.Result;
        if (command.Observation is not null) Observation = command.Observation;
    }
}