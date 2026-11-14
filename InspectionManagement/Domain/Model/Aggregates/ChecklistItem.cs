using Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Domain.Model.Aggregates.Internal;

namespace Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;

public class ChecklistItem : AggregateRoot
{
    protected ChecklistItem()
    {
    }

    public ChecklistItem(CreateChecklistItemCommand command)
    {
        ChecklistId = command.ChecklistId;
        Description = command.Description;
        SortOrder = command.SortOrder;
        IsRequired = command.IsRequired;
    }

    public int Id { get; private set; }
    public int ChecklistId { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public int SortOrder { get; private set; }
    public bool IsRequired { get; private set; }

    public void Update(UpdateChecklistItemCommand command)
    {
        ChecklistId = command.ChecklistId;
        Description = command.Description;
        SortOrder = command.SortOrder;
        IsRequired = command.IsRequired;
    }

    public void Patch(PatchChecklistItemCommand command)
    {
        if (command.ChecklistId is not null) ChecklistId = command.ChecklistId.Value;
        if (command.Description is not null) Description = command.Description;
        if (command.SortOrder is not null) SortOrder = command.SortOrder.Value;
        if (command.IsRequired is not null) IsRequired = command.IsRequired.Value;
    }
}