using Fleet.Care.Platform.IncidentManagement.Domain.Model.Commands;
using Fleet.Care.Platform.Shared.Domain.Model.Aggregates.Internal;

namespace Fleet.Care.Platform.IncidentManagement.Domain.Model.Aggregates;

public class Incident : AggregateRoot
{
    protected Incident()
    {
    }

    public Incident(CreateIncidentCommand command)
    {
        VehicleId = command.VehicleId;
        ReportedByUserId = command.ReportedByUserId;
        SourceInspectionId = command.SourceInspectionId;
        Title = command.Title;
        Description = command.Description;
        Status = command.Status;
        Latitude = command.Latitude;
        Longitude = command.Longitude;
        Address = command.Address;
        ReportedAt = command.ReportedAt;
        ResolvedAt = command.ResolvedAt;
        Resolution = command.Resolution;
        CreatedAt = command.CreatedAt;
        UpdatedAt = command.UpdatedAt;
    }

    public int Id { get; private set; }
    public int VehicleId { get; private set; }
    public int ReportedByUserId { get; private set; }
    public int? SourceInspectionId { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Status { get; private set; } = string.Empty;
    public decimal? Latitude { get; private set; }
    public decimal? Longitude { get; private set; }
    public string? Address { get; private set; }
    public DateTimeOffset ReportedAt { get; private set; }
    public DateTimeOffset? ResolvedAt { get; private set; }
    public string? Resolution { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset UpdatedAt { get; private set; }

    public void Update(UpdateIncidentCommand command)
    {
        VehicleId = command.VehicleId;
        ReportedByUserId = command.ReportedByUserId;
        SourceInspectionId = command.SourceInspectionId;
        Title = command.Title;
        Description = command.Description;
        Status = command.Status;
        Latitude = command.Latitude;
        Longitude = command.Longitude;
        Address = command.Address;
        ReportedAt = command.ReportedAt;
        ResolvedAt = command.ResolvedAt;
        Resolution = command.Resolution;
        CreatedAt = command.CreatedAt;
        UpdatedAt = command.UpdatedAt;
    }

    public void Patch(PatchIncidentCommand command)
    {
        if (command.VehicleId is not null) VehicleId = command.VehicleId.Value;
        if (command.ReportedByUserId is not null) ReportedByUserId = command.ReportedByUserId.Value;
        if (command.SourceInspectionId is not null) SourceInspectionId = command.SourceInspectionId;
        if (command.Title is not null) Title = command.Title;
        if (command.Description is not null) Description = command.Description;
        if (command.Status is not null) Status = command.Status;
        if (command.Latitude is not null) Latitude = command.Latitude;
        if (command.Longitude is not null) Longitude = command.Longitude;
        if (command.Address is not null) Address = command.Address;
        if (command.ReportedAt is not null) ReportedAt = command.ReportedAt.Value;
        if (command.ResolvedAt is not null) ResolvedAt = command.ResolvedAt;
        if (command.Resolution is not null) Resolution = command.Resolution;
        if (command.CreatedAt is not null) CreatedAt = command.CreatedAt.Value;
        if (command.UpdatedAt is not null) UpdatedAt = command.UpdatedAt.Value;
    }
}