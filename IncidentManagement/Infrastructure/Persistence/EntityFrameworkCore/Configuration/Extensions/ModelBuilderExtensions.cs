using Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.IncidentManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Care.Platform.IncidentManagement.Infrastructure.Persistence.EntityFrameworkCore.Configuration.
    Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyIncidentManagementConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Incident>().ToTable("incidents");
        builder.Entity<Incident>().HasKey(x => x.Id);
        builder.Entity<Incident>().Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Entity<Incident>().Property(x => x.VehicleId).IsRequired();
        builder.Entity<Incident>().Property(x => x.ReportedByUserId).IsRequired();
        builder.Entity<Incident>().Property(x => x.SourceInspectionId);
        builder.Entity<Incident>().Property(x => x.Title).IsRequired().HasMaxLength(200);
        builder.Entity<Incident>().Property(x => x.Description).IsRequired().HasMaxLength(2000);
        builder.Entity<Incident>().Property(x => x.Status).IsRequired().HasMaxLength(30);
        builder.Entity<Incident>().Property(x => x.Latitude).HasPrecision(9, 6);
        builder.Entity<Incident>().Property(x => x.Longitude).HasPrecision(9, 6);
        builder.Entity<Incident>().Property(x => x.Address).HasMaxLength(500);
        builder.Entity<Incident>().Property(x => x.ReportedAt).IsRequired();
        builder.Entity<Incident>().Property(x => x.ResolvedAt);
        builder.Entity<Incident>().Property(x => x.Resolution).HasMaxLength(2000);
        builder.Entity<Incident>().Property(x => x.CreatedAt).IsRequired();
        builder.Entity<Incident>().Property(x => x.UpdatedAt).IsRequired();
        builder.Entity<IncidentEvidence>().ToTable("incident_evidences");
        builder.Entity<IncidentEvidence>().HasKey(x => x.Id);
        builder.Entity<IncidentEvidence>().Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Entity<IncidentEvidence>().Property(x => x.IncidentId).IsRequired();
        builder.Entity<IncidentEvidence>().Property(x => x.FileUrl).IsRequired().HasMaxLength(1000);
        builder.Entity<IncidentEvidence>().Property(x => x.Description).HasMaxLength(500);
        builder.Entity<IncidentEvidence>().Property(x => x.CreatedAt).IsRequired();

        builder.Entity<IncidentEvidence>().HasOne<Incident>().WithMany().HasForeignKey(x => x.IncidentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Cross-context database relationships; domain keeps external aggregate references as scalar IDs.
        builder.Entity<Incident>().HasOne<Vehicle>().WithMany().HasForeignKey(x => x.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Incident>().HasOne<Inspection>().WithMany().HasForeignKey(x => x.SourceInspectionId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}