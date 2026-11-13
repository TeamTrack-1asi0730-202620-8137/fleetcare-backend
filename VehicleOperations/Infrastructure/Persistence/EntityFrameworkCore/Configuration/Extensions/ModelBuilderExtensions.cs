using Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Care.Platform.VehicleOperations.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyVehicleOperationsConfiguration(this ModelBuilder builder)
    {
        builder.Entity<MileageRecord>().ToTable("mileage_records");
        builder.Entity<MileageRecord>().HasKey(x => x.Id);
        builder.Entity<MileageRecord>().Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Entity<MileageRecord>().Property(x => x.VehicleId).IsRequired();
        builder.Entity<MileageRecord>().Property(x => x.RegisteredByUserId).IsRequired();
        builder.Entity<MileageRecord>().Property(x => x.Mileage).IsRequired().HasPrecision(12, 2);
        builder.Entity<MileageRecord>().Property(x => x.RecordedAt).IsRequired();
        builder.Entity<MileageRecord>().Property(x => x.CreatedAt).IsRequired();
        builder.Entity<FuelRecord>().ToTable("fuel_records");
        builder.Entity<FuelRecord>().HasKey(x => x.Id);
        builder.Entity<FuelRecord>().Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Entity<FuelRecord>().Property(x => x.VehicleId).IsRequired();
        builder.Entity<FuelRecord>().Property(x => x.RegisteredByUserId).IsRequired();
        builder.Entity<FuelRecord>().Property(x => x.Mileage).IsRequired().HasPrecision(12, 2);
        builder.Entity<FuelRecord>().Property(x => x.Liters).IsRequired().HasPrecision(12, 2);
        builder.Entity<FuelRecord>().Property(x => x.TotalCost).IsRequired().HasPrecision(12, 2);
        builder.Entity<FuelRecord>().Property(x => x.FueledAt).IsRequired();
        builder.Entity<FuelRecord>().Property(x => x.CreatedAt).IsRequired();


        // Cross-context database relationships; domain keeps VehicleId as a scalar reference.
        builder.Entity<MileageRecord>().HasOne<Vehicle>().WithMany().HasForeignKey(x => x.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<FuelRecord>().HasOne<Vehicle>().WithMany().HasForeignKey(x => x.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}