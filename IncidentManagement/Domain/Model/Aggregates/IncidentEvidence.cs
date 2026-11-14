using Fleet.Care.Platform.IncidentManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Domain.Model.Aggregates.Internal;

namespace Fleet.Care.Platform.IncidentManagement.Domain.Model.Aggregates;

public class IncidentEvidence : AggregateRoot
{
    protected IncidentEvidence()
    {
    }

    public IncidentEvidence(CreateIncidentEvidenceCommand command)
    {
        IncidentId = command.IncidentId;
        FileUrl = command.FileUrl;
        Description = command.Description;
        CreatedAt = command.CreatedAt;
    }

    public int Id { get; private set; }
    public int IncidentId { get; private set; }
    public string FileUrl { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    public void Update(UpdateIncidentEvidenceCommand command)
    {
        IncidentId = command.IncidentId;
        FileUrl = command.FileUrl;
        Description = command.Description;
        CreatedAt = command.CreatedAt;
    }

    public void Patch(PatchIncidentEvidenceCommand command)
    {
        if (command.IncidentId is not null) IncidentId = command.IncidentId.Value;
        if (command.FileUrl is not null) FileUrl = command.FileUrl;
        if (command.Description is not null) Description = command.Description;
        if (command.CreatedAt is not null) CreatedAt = command.CreatedAt.Value;
    }
}