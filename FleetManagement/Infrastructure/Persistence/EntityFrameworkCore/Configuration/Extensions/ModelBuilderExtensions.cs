using Fleet.Care.Platform.FleetManagement.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Care.Platform.FleetManagement.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyFleetManagementConfiguration(this ModelBuilder builder)
    {
        builder.Entity<FleetAggregate>().ToTable("fleets");
        builder.Entity<FleetAggregate>().HasKey(x => x.Id);
        builder.Entity<FleetAggregate>().Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Entity<FleetAggregate>().Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Entity<FleetAggregate>().Property(x => x.CreatedAt).IsRequired();
        builder.Entity<FleetAggregate>().Property(x => x.UpdatedAt).IsRequired();
        builder.Entity<Vehicle>().ToTable("vehicles");
        builder.Entity<Vehicle>().HasKey(x => x.Id);
        builder.Entity<Vehicle>().Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Entity<Vehicle>().Property(x => x.FleetId).IsRequired();
        builder.Entity<Vehicle>().Property(x => x.PlateNumber).IsRequired().HasMaxLength(20);
        builder.Entity<Vehicle>().Property(x => x.Brand).IsRequired().HasMaxLength(100);
        builder.Entity<Vehicle>().Property(x => x.Model).IsRequired().HasMaxLength(100);
        builder.Entity<Vehicle>().Property(x => x.Year).IsRequired();
        builder.Entity<Vehicle>().Property(x => x.Vin).HasMaxLength(50);
        builder.Entity<Vehicle>().Property(x => x.Status).IsRequired().HasMaxLength(30);
        builder.Entity<Vehicle>().Property(x => x.CreatedAt).IsRequired();
        builder.Entity<Vehicle>().Property(x => x.UpdatedAt).IsRequired();

        builder.Entity<Vehicle>().HasOne<FleetAggregate>().WithMany().HasForeignKey(x => x.FleetId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}