using Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Domain.Model.Aggregates.Internal;

namespace Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;

public class Checklist : AggregateRoot
{
    protected Checklist()
    {
    }

    public Checklist(CreateChecklistCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        IsActive = command.IsActive;
        CreatedAt = command.CreatedAt;
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public bool IsActive { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    public void Update(UpdateChecklistCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        IsActive = command.IsActive;
        CreatedAt = command.CreatedAt;
    }

    public void Patch(PatchChecklistCommand command)
    {
        if (command.Name is not null) Name = command.Name;
        if (command.Description is not null) Description = command.Description;
        if (command.IsActive is not null) IsActive = command.IsActive.Value;
        if (command.CreatedAt is not null) CreatedAt = command.CreatedAt.Value;
    }
}