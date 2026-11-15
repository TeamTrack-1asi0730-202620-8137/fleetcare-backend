using Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Care.Platform.InspectionManagement.Infrastructure.Persistence.EntityFrameworkCore.Configuration.
    Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyInspectionManagementConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Checklist>().ToTable("checklists");
        builder.Entity<Checklist>().HasKey(x => x.Id);
        builder.Entity<Checklist>().Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Entity<Checklist>().Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Entity<Checklist>().Property(x => x.Description).HasMaxLength(500);
        builder.Entity<Checklist>().Property(x => x.IsActive).IsRequired();
        builder.Entity<Checklist>().Property(x => x.CreatedAt).IsRequired();
        builder.Entity<ChecklistItem>().ToTable("checklist_items");
        builder.Entity<ChecklistItem>().HasKey(x => x.Id);
        builder.Entity<ChecklistItem>().Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Entity<ChecklistItem>().Property(x => x.ChecklistId).IsRequired();
        builder.Entity<ChecklistItem>().Property(x => x.Description).IsRequired().HasMaxLength(500);
        builder.Entity<ChecklistItem>().Property(x => x.SortOrder).IsRequired();
        builder.Entity<ChecklistItem>().Property(x => x.IsRequired).IsRequired();
        builder.Entity<Inspection>().ToTable("inspections");
        builder.Entity<Inspection>().HasKey(x => x.Id);
        builder.Entity<Inspection>().Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Entity<Inspection>().Property(x => x.VehicleId).IsRequired();
        builder.Entity<Inspection>().Property(x => x.ChecklistId).IsRequired();
        builder.Entity<Inspection>().Property(x => x.DriverId).IsRequired();
        builder.Entity<Inspection>().Property(x => x.InspectionDate).IsRequired();
        builder.Entity<Inspection>().Property(x => x.Status).IsRequired().HasMaxLength(30);
        builder.Entity<Inspection>().Property(x => x.Observation).HasMaxLength(1000);
        builder.Entity<Inspection>().Property(x => x.CreatedAt).IsRequired();
        builder.Entity<Inspection>().Property(x => x.CompletedAt);
        builder.Entity<InspectionResult>().ToTable("inspection_results");
        builder.Entity<InspectionResult>().HasKey(x => x.Id);
        builder.Entity<InspectionResult>().Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Entity<InspectionResult>().Property(x => x.InspectionId).IsRequired();
        builder.Entity<InspectionResult>().Property(x => x.ChecklistItemId).IsRequired();
        builder.Entity<InspectionResult>().Property(x => x.Result).IsRequired().HasMaxLength(30);
        builder.Entity<InspectionResult>().Property(x => x.Observation).HasMaxLength(1000);
        builder.Entity<InspectionEvidence>().ToTable("inspection_evidences");
        builder.Entity<InspectionEvidence>().HasKey(x => x.Id);
        builder.Entity<InspectionEvidence>().Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Entity<InspectionEvidence>().Property(x => x.InspectionId).IsRequired();
        builder.Entity<InspectionEvidence>().Property(x => x.FileUrl).IsRequired().HasMaxLength(1000);
        builder.Entity<InspectionEvidence>().Property(x => x.Description).HasMaxLength(500);
        builder.Entity<InspectionEvidence>().Property(x => x.CreatedAt).IsRequired();

        builder.Entity<ChecklistItem>().HasOne<Checklist>().WithMany().HasForeignKey(x => x.ChecklistId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Inspection>().HasOne<Checklist>().WithMany().HasForeignKey(x => x.ChecklistId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<InspectionResult>().HasOne<Inspection>().WithMany().HasForeignKey(x => x.InspectionId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<InspectionResult>().HasOne<ChecklistItem>().WithMany().HasForeignKey(x => x.ChecklistItemId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<InspectionEvidence>().HasOne<Inspection>().WithMany().HasForeignKey(x => x.InspectionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Cross-context database relationship; domain keeps VehicleId as a scalar reference.
        builder.Entity<Inspection>().HasOne<Vehicle>().WithMany().HasForeignKey(x => x.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}