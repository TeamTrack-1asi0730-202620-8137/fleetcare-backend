using Fleet.Care.Platform.FleetManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Domain.Model.Aggregates.Internal;

namespace Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;

public class FleetAggregate : AggregateRoot
{
    protected FleetAggregate()
    {
    }

    public FleetAggregate(CreateFleetCommand command)
    {
        Name = command.Name;
        CreatedAt = command.CreatedAt;
        UpdatedAt = command.UpdatedAt;
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset UpdatedAt { get; private set; }

    public void Update(UpdateFleetCommand command)
    {
        Name = command.Name;
        CreatedAt = command.CreatedAt;
        UpdatedAt = command.UpdatedAt;
    }

    public void Patch(PatchFleetCommand command)
    {
        if (command.Name is not null) Name = command.Name;
        if (command.CreatedAt is not null) CreatedAt = command.CreatedAt.Value;
        if (command.UpdatedAt is not null) UpdatedAt = command.UpdatedAt.Value;
    }
}