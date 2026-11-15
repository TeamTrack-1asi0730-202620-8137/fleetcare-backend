using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Fleet.Care.Platform.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "checklists",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_checklists", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "fleets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_fleets", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "checklist_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    checklist_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    sort_order = table.Column<int>(type: "int", nullable: false),
                    is_required = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_checklist_items", x => x.id);
                    table.ForeignKey(
                        name: "f_k_checklist_items_checklists_checklist_id",
                        column: x => x.checklist_id,
                        principalTable: "checklists",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    fleet_id = table.Column<int>(type: "int", nullable: false),
                    plate_number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    brand = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    model = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    vin = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    status = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_vehicles", x => x.id);
                    table.ForeignKey(
                        name: "f_k_vehicles_fleets_fleet_id",
                        column: x => x.fleet_id,
                        principalTable: "fleets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "fuel_records",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    vehicle_id = table.Column<int>(type: "int", nullable: false),
                    registered_by_user_id = table.Column<int>(type: "int", nullable: false),
                    mileage = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    liters = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    total_cost = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    fueled_at = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_fuel_records", x => x.id);
                    table.ForeignKey(
                        name: "f_k_fuel_records_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inspections",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    vehicle_id = table.Column<int>(type: "int", nullable: false),
                    checklist_id = table.Column<int>(type: "int", nullable: false),
                    driver_id = table.Column<int>(type: "int", nullable: false),
                    inspection_date = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                    status = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    observation = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                    completed_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_inspections", x => x.id);
                    table.ForeignKey(
                        name: "f_k_inspections_checklists_checklist_id",
                        column: x => x.checklist_id,
                        principalTable: "checklists",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "f_k_inspections_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mileage_records",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    vehicle_id = table.Column<int>(type: "int", nullable: false),
                    registered_by_user_id = table.Column<int>(type: "int", nullable: false),
                    mileage = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    recorded_at = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_mileage_records", x => x.id);
                    table.ForeignKey(
                        name: "f_k_mileage_records_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "incidents",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    vehicle_id = table.Column<int>(type: "int", nullable: false),
                    reported_by_user_id = table.Column<int>(type: "int", nullable: false),
                    source_inspection_id = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    status = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: true),
                    longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: true),
                    address = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    reported_at = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                    resolved_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    resolution = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_incidents", x => x.id);
                    table.ForeignKey(
                        name: "f_k_incidents_inspections_source_inspection_id",
                        column: x => x.source_inspection_id,
                        principalTable: "inspections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "f_k_incidents_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inspection_evidences",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    inspection_id = table.Column<int>(type: "int", nullable: false),
                    file_url = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_inspection_evidences", x => x.id);
                    table.ForeignKey(
                        name: "f_k_inspection_evidences_inspections_inspection_id",
                        column: x => x.inspection_id,
                        principalTable: "inspections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inspection_results",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    inspection_id = table.Column<int>(type: "int", nullable: false),
                    checklist_item_id = table.Column<int>(type: "int", nullable: false),
                    result = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    observation = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_inspection_results", x => x.id);
                    table.ForeignKey(
                        name: "f_k_inspection_results_checklist_items_checklist_item_id",
                        column: x => x.checklist_item_id,
                        principalTable: "checklist_items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "f_k_inspection_results_inspections_inspection_id",
                        column: x => x.inspection_id,
                        principalTable: "inspections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "incident_evidences",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    incident_id = table.Column<int>(type: "int", nullable: false),
                    file_url = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_incident_evidences", x => x.id);
                    table.ForeignKey(
                        name: "f_k_incident_evidences_incidents_incident_id",
                        column: x => x.incident_id,
                        principalTable: "incidents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "maintenance_plans",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    vehicle_id = table.Column<int>(type: "int", nullable: false),
                    related_incident_id = table.Column<int>(type: "int", nullable: true),
                    maintenance_type = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    scheduled_date = table.Column<DateOnly>(type: "date", nullable: true),
                    target_mileage = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: true),
                    status = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    notes = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_maintenance_plans", x => x.id);
                    table.ForeignKey(
                        name: "f_k_maintenance_plans_incidents_related_incident_id",
                        column: x => x.related_incident_id,
                        principalTable: "incidents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "f_k_maintenance_plans_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "maintenance_records",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    maintenance_plan_id = table.Column<int>(type: "int", nullable: true),
                    vehicle_id = table.Column<int>(type: "int", nullable: false),
                    maintenance_type = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    performed_date = table.Column<DateOnly>(type: "date", nullable: false),
                    mileage = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    work_description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    total_cost = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    notes = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_maintenance_records", x => x.id);
                    table.ForeignKey(
                        name: "f_k_maintenance_records_maintenance_plans_maintenance_plan_id",
                        column: x => x.maintenance_plan_id,
                        principalTable: "maintenance_plans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "f_k_maintenance_records_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "maintenance_parts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    maintenance_record_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    unit_cost = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_maintenance_parts", x => x.id);
                    table.ForeignKey(
                        name: "f_k_maintenance_parts_maintenance_records_maintenance_record_id",
                        column: x => x.maintenance_record_id,
                        principalTable: "maintenance_records",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "i_x_checklist_items_checklist_id",
                table: "checklist_items",
                column: "checklist_id");

            migrationBuilder.CreateIndex(
                name: "i_x_fuel_records_vehicle_id",
                table: "fuel_records",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "i_x_incident_evidences_incident_id",
                table: "incident_evidences",
                column: "incident_id");

            migrationBuilder.CreateIndex(
                name: "i_x_incidents_source_inspection_id",
                table: "incidents",
                column: "source_inspection_id");

            migrationBuilder.CreateIndex(
                name: "i_x_incidents_vehicle_id",
                table: "incidents",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "i_x_inspection_evidences_inspection_id",
                table: "inspection_evidences",
                column: "inspection_id");

            migrationBuilder.CreateIndex(
                name: "i_x_inspection_results_checklist_item_id",
                table: "inspection_results",
                column: "checklist_item_id");

            migrationBuilder.CreateIndex(
                name: "i_x_inspection_results_inspection_id",
                table: "inspection_results",
                column: "inspection_id");

            migrationBuilder.CreateIndex(
                name: "i_x_inspections_checklist_id",
                table: "inspections",
                column: "checklist_id");

            migrationBuilder.CreateIndex(
                name: "i_x_inspections_vehicle_id",
                table: "inspections",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "i_x_maintenance_parts_maintenance_record_id",
                table: "maintenance_parts",
                column: "maintenance_record_id");

            migrationBuilder.CreateIndex(
                name: "i_x_maintenance_plans_related_incident_id",
                table: "maintenance_plans",
                column: "related_incident_id");

            migrationBuilder.CreateIndex(
                name: "i_x_maintenance_plans_vehicle_id",
                table: "maintenance_plans",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "i_x_maintenance_records_maintenance_plan_id",
                table: "maintenance_records",
                column: "maintenance_plan_id");

            migrationBuilder.CreateIndex(
                name: "i_x_maintenance_records_vehicle_id",
                table: "maintenance_records",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "i_x_mileage_records_vehicle_id",
                table: "mileage_records",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "i_x_vehicles_fleet_id",
                table: "vehicles",
                column: "fleet_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fuel_records");

            migrationBuilder.DropTable(
                name: "incident_evidences");

            migrationBuilder.DropTable(
                name: "inspection_evidences");

            migrationBuilder.DropTable(
                name: "inspection_results");

            migrationBuilder.DropTable(
                name: "maintenance_parts");

            migrationBuilder.DropTable(
                name: "mileage_records");

            migrationBuilder.DropTable(
                name: "checklist_items");

            migrationBuilder.DropTable(
                name: "maintenance_records");

            migrationBuilder.DropTable(
                name: "maintenance_plans");

            migrationBuilder.DropTable(
                name: "incidents");

            migrationBuilder.DropTable(
                name: "inspections");

            migrationBuilder.DropTable(
                name: "checklists");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "fleets");
        }
    }
}
