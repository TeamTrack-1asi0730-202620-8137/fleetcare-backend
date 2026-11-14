using Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.IncidentManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Care.Platform.MaintenanceManagement.Infrastructure.Persistence.EntityFrameworkCore.Configuration.
    Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyMaintenanceManagementConfiguration(this ModelBuilder builder)
    {
        builder.Entity<MaintenancePlan>().ToTable("maintenance_plans");
        builder.Entity<MaintenancePlan>().HasKey(x => x.Id);
        builder.Entity<MaintenancePlan>().Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Entity<MaintenancePlan>().Property(x => x.VehicleId).IsRequired();
        builder.Entity<MaintenancePlan>().Property(x => x.RelatedIncidentId);
        builder.Entity<MaintenancePlan>().Property(x => x.MaintenanceType).IsRequired().HasMaxLength(100);
        builder.Entity<MaintenancePlan>().Property(x => x.ScheduledDate);
        builder.Entity<MaintenancePlan>().Property(x => x.TargetMileage).HasPrecision(12, 2);
        builder.Entity<MaintenancePlan>().Property(x => x.Status).IsRequired().HasMaxLength(30);
        builder.Entity<MaintenancePlan>().Property(x => x.Notes).HasMaxLength(1000);
        builder.Entity<MaintenancePlan>().Property(x => x.CreatedAt).IsRequired();
        builder.Entity<MaintenancePlan>().Property(x => x.UpdatedAt).IsRequired();
        builder.Entity<MaintenanceRecord>().ToTable("maintenance_records");
        builder.Entity<MaintenanceRecord>().HasKey(x => x.Id);
        builder.Entity<MaintenanceRecord>().Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Entity<MaintenanceRecord>().Property(x => x.MaintenancePlanId);
        builder.Entity<MaintenanceRecord>().Property(x => x.VehicleId).IsRequired();
        builder.Entity<MaintenanceRecord>().Property(x => x.MaintenanceType).IsRequired().HasMaxLength(100);
        builder.Entity<MaintenanceRecord>().Property(x => x.PerformedDate).IsRequired();
        builder.Entity<MaintenanceRecord>().Property(x => x.Mileage).IsRequired().HasPrecision(12, 2);
        builder.Entity<MaintenanceRecord>().Property(x => x.WorkDescription).IsRequired().HasMaxLength(2000);
        builder.Entity<MaintenanceRecord>().Property(x => x.TotalCost).IsRequired().HasPrecision(12, 2);
        builder.Entity<MaintenanceRecord>().Property(x => x.Notes).HasMaxLength(1000);
        builder.Entity<MaintenanceRecord>().Property(x => x.CreatedAt).IsRequired();
        builder.Entity<MaintenancePart>().ToTable("maintenance_parts");
        builder.Entity<MaintenancePart>().HasKey(x => x.Id);
        builder.Entity<MaintenancePart>().Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Entity<MaintenancePart>().Property(x => x.MaintenanceRecordId).IsRequired();
        builder.Entity<MaintenancePart>().Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Entity<MaintenancePart>().Property(x => x.Quantity).IsRequired();
        builder.Entity<MaintenancePart>().Property(x => x.UnitCost).IsRequired().HasPrecision(12, 2);

        builder.Entity<MaintenanceRecord>().HasOne<MaintenancePlan>().WithMany().HasForeignKey(x => x.MaintenancePlanId)
            .OnDelete(DeleteBehavior.SetNull);
        builder.Entity<MaintenancePart>().HasOne<MaintenanceRecord>().WithMany()
            .HasForeignKey(x => x.MaintenanceRecordId).OnDelete(DeleteBehavior.Cascade);

        // Cross-context database relationships; domain keeps external aggregate references as scalar IDs.
        builder.Entity<MaintenancePlan>().HasOne<Vehicle>().WithMany().HasForeignKey(x => x.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<MaintenancePlan>().HasOne<Incident>().WithMany().HasForeignKey(x => x.RelatedIncidentId)
            .OnDelete(DeleteBehavior.SetNull);
        builder.Entity<MaintenanceRecord>().HasOne<Vehicle>().WithMany().HasForeignKey(x => x.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}