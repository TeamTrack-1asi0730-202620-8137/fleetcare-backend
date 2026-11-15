using Fleet.Care.Platform.InspectionManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Domain.Model.Aggregates.Internal;

namespace Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;

public class InspectionEvidence : AggregateRoot
{
    protected InspectionEvidence()
    {
    }

    public InspectionEvidence(CreateInspectionEvidenceCommand command)
    {
        InspectionId = command.InspectionId;
        FileUrl = command.FileUrl;
        Description = command.Description;
        CreatedAt = command.CreatedAt;
    }

    public int Id { get; private set; }
    public int InspectionId { get; private set; }
    public string FileUrl { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    public void Update(UpdateInspectionEvidenceCommand command)
    {
        InspectionId = command.InspectionId;
        FileUrl = command.FileUrl;
        Description = command.Description;
        CreatedAt = command.CreatedAt;
    }

    public void Patch(PatchInspectionEvidenceCommand command)
    {
        if (command.InspectionId is not null) InspectionId = command.InspectionId.Value;
        if (command.FileUrl is not null) FileUrl = command.FileUrl;
        if (command.Description is not null) Description = command.Description;
        if (command.CreatedAt is not null) CreatedAt = command.CreatedAt.Value;
    }
}