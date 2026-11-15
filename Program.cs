using Cortex.Mediator.Commands;
using Cortex.Mediator.DependencyInjection;
using Fleet.Care.Platform.FleetManagement.Application.CommandServices;
using Fleet.Care.Platform.FleetManagement.Application.Internal.CommandServices;
using Fleet.Care.Platform.FleetManagement.Application.Internal.QueryServices;
using Fleet.Care.Platform.FleetManagement.Application.QueryServices;
using Fleet.Care.Platform.FleetManagement.Domain.Repositories;
using Fleet.Care.Platform.FleetManagement.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Fleet.Care.Platform.IncidentManagement.Application.CommandServices;
using Fleet.Care.Platform.IncidentManagement.Application.Internal.CommandServices;
using Fleet.Care.Platform.IncidentManagement.Application.Internal.QueryServices;
using Fleet.Care.Platform.IncidentManagement.Application.QueryServices;
using Fleet.Care.Platform.IncidentManagement.Domain.Repositories;
using Fleet.Care.Platform.IncidentManagement.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Fleet.Care.Platform.InspectionManagement.Application.CommandServices;
using Fleet.Care.Platform.InspectionManagement.Application.Internal.CommandServices;
using Fleet.Care.Platform.InspectionManagement.Application.Internal.QueryServices;
using Fleet.Care.Platform.InspectionManagement.Application.QueryServices;
using Fleet.Care.Platform.InspectionManagement.Domain.Repositories;
using Fleet.Care.Platform.InspectionManagement.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Fleet.Care.Platform.MaintenanceManagement.Application.CommandServices;
using Fleet.Care.Platform.MaintenanceManagement.Application.Internal.CommandServices;
using Fleet.Care.Platform.MaintenanceManagement.Application.Internal.QueryServices;
using Fleet.Care.Platform.MaintenanceManagement.Application.QueryServices;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Repositories;
using Fleet.Care.Platform.MaintenanceManagement.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

using Fleet.Care.Platform.Resources.Errors;
using Fleet.Care.Platform.Resources.Shared;
using Fleet.Care.Platform.Shared.Domain.Repositories;
using Fleet.Care.Platform.Shared.Infrastructure.Interfaces.AspNetCore.Configuration;
using Fleet.Care.Platform.Shared.Infrastructure.Interfaces.AspNetCore.OpenApi;
using Fleet.Care.Platform.Shared.Infrastructure.Mediator.Cortex.Configuration;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Interceptors;
using Fleet.Care.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Fleet.Care.Platform.Shared.Infrastructure.Pipeline.Middleware.Components;
using Fleet.Care.Platform.VehicleOperations.Application.CommandServices;
using Fleet.Care.Platform.VehicleOperations.Application.Internal.CommandServices;
using Fleet.Care.Platform.VehicleOperations.Application.Internal.QueryServices;
using Fleet.Care.Platform.VehicleOperations.Application.QueryServices;
using Fleet.Care.Platform.VehicleOperations.Domain.Repositories;
using Fleet.Care.Platform.VehicleOperations.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Scalar.AspNetCore;
// Added for ProblemDetailsFactory
// Added for base ProblemDetailsFactory
// Added for IamMessages
// Added for ProfilesMessages
using ProblemDetailsFactory = Fleet.Care.Platform.Shared.Interfaces.Rest.ProblemDetails.ProblemDetailsFactory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()))
    .AddDataAnnotationsLocalization();

// Add ProblemDetails and ExceptionHandler services
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();


// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add Database Connection

// Configure Database Context and route EF logs through the app logger pipeline.
builder.Services.AddDbContext<AppDbContext>((serviceProvider, options) =>
{
    var connectionStringTemplate = builder.Configuration.GetConnectionString("DefaultConnection");
    if (string.IsNullOrWhiteSpace(connectionStringTemplate))
        throw new InvalidOperationException("Database connection string is not set in the configuration.");

    var connectionString = Environment.ExpandEnvironmentVariables(connectionStringTemplate);
    if (string.IsNullOrWhiteSpace(connectionString))
        throw new InvalidOperationException("Database connection string is not set in the configuration.");

    options.UseMySQL(connectionString)
        .UseLoggerFactory(serviceProvider.GetRequiredService<ILoggerFactory>())
        .AddInterceptors(serviceProvider.GetRequiredService<DispatchDomainEventsInterceptor>())
        .EnableDetailedErrors();

    if (builder.Environment.IsDevelopment())
        options.EnableSensitiveDataLogging();
});

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Explicitly register IStringLocalizer for ErrorMessages and Commons
builder.Services.AddSingleton<IStringLocalizer<ErrorMessages>, StringLocalizer<ErrorMessages>>();
builder.Services
    .AddSingleton<IStringLocalizer<CommonMessages>,
        StringLocalizer<CommonMessages>>(); // Corrected from Common to Commons

// Register the custom ProblemDetailsFactory
builder.Services.AddSingleton<ProblemDetailsFactory>();


// OpenAPI / Scalar documentation
builder.Services.AddOpenApi(options => { options.AddDocumentTransformer<BearerSecuritySchemeTransformer>(); });

// Dependency Injection

// Shared Bounded Context
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<DispatchDomainEventsInterceptor>();

// Publishing Bounded Context

// Profiles Bounded Context 


// FleetCare Business Bounded Contexts Dependency Injection Configuration
// FleetManagement Bounded Context
builder.Services.AddScoped<IFleetRepository, FleetRepository>();
builder.Services.AddScoped<IFleetQueryService, FleetQueryService>();
builder.Services.AddScoped<IFleetCommandService, FleetCommandService>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleQueryService, VehicleQueryService>();
builder.Services.AddScoped<IVehicleCommandService, VehicleCommandService>();

// InspectionManagement Bounded Context
builder.Services.AddScoped<IChecklistRepository, ChecklistRepository>();
builder.Services.AddScoped<IChecklistQueryService, ChecklistQueryService>();
builder.Services.AddScoped<IChecklistCommandService, ChecklistCommandService>();
builder.Services.AddScoped<IChecklistItemRepository, ChecklistItemRepository>();
builder.Services.AddScoped<IChecklistItemQueryService, ChecklistItemQueryService>();
builder.Services.AddScoped<IChecklistItemCommandService, ChecklistItemCommandService>();
builder.Services.AddScoped<IInspectionRepository, InspectionRepository>();
builder.Services.AddScoped<IInspectionQueryService, InspectionQueryService>();
builder.Services.AddScoped<IInspectionCommandService, InspectionCommandService>();
builder.Services.AddScoped<IInspectionResultRepository, InspectionResultRepository>();
builder.Services.AddScoped<IInspectionResultQueryService, InspectionResultQueryService>();
builder.Services.AddScoped<IInspectionResultCommandService, InspectionResultCommandService>();
builder.Services.AddScoped<IInspectionEvidenceRepository, InspectionEvidenceRepository>();
builder.Services.AddScoped<IInspectionEvidenceQueryService, InspectionEvidenceQueryService>();
builder.Services.AddScoped<IInspectionEvidenceCommandService, InspectionEvidenceCommandService>();

// IncidentManagement Bounded Context
builder.Services.AddScoped<IIncidentRepository, IncidentRepository>();
builder.Services.AddScoped<IIncidentQueryService, IncidentQueryService>();
builder.Services.AddScoped<IIncidentCommandService, IncidentCommandService>();
builder.Services.AddScoped<IIncidentEvidenceRepository, IncidentEvidenceRepository>();
builder.Services.AddScoped<IIncidentEvidenceQueryService, IncidentEvidenceQueryService>();
builder.Services.AddScoped<IIncidentEvidenceCommandService, IncidentEvidenceCommandService>();

// MaintenanceManagement Bounded Context
builder.Services.AddScoped<IMaintenancePlanRepository, MaintenancePlanRepository>();
builder.Services.AddScoped<IMaintenancePlanQueryService, MaintenancePlanQueryService>();
builder.Services.AddScoped<IMaintenancePlanCommandService, MaintenancePlanCommandService>();
builder.Services.AddScoped<IMaintenanceRecordRepository, MaintenanceRecordRepository>();
builder.Services.AddScoped<IMaintenanceRecordQueryService, MaintenanceRecordQueryService>();
builder.Services.AddScoped<IMaintenanceRecordCommandService, MaintenanceRecordCommandService>();
builder.Services.AddScoped<IMaintenancePartRepository, MaintenancePartRepository>();
builder.Services.AddScoped<IMaintenancePartQueryService, MaintenancePartQueryService>();
builder.Services.AddScoped<IMaintenancePartCommandService, MaintenancePartCommandService>();

// VehicleOperations Bounded Context
builder.Services.AddScoped<IMileageRecordRepository, MileageRecordRepository>();
builder.Services.AddScoped<IMileageRecordQueryService, MileageRecordQueryService>();
builder.Services.AddScoped<IMileageRecordCommandService, MileageRecordCommandService>();
builder.Services.AddScoped<IFuelRecordRepository, FuelRecordRepository>();
builder.Services.AddScoped<IFuelRecordQueryService, FuelRecordQueryService>();
builder.Services.AddScoped<IFuelRecordCommandService, FuelRecordCommandService>();


// IAM Bounded Context Injection Configuration

// TokenSettings Configuration


// Mediator Configuration

// Add Mediator Injection Configuration
builder.Services.AddScoped(typeof(ICommandPipelineBehavior<>), typeof(LoggingCommandBehavior<>));
builder.Services.AddScoped(typeof(ICommandPipelineBehavior<>), typeof(ExceptionHandlingCommandBehavior<>));
builder.Services.AddScoped(typeof(ICommandPipelineBehavior<>), typeof(TransactionCommandBehavior<>));

// Add Cortex Mediator for Event Handling
builder.Services.AddCortexMediator(
    [typeof(Program)]);


var app = builder.Build();

// Apply pending migrations on startup (safe to call even when schema is up to date)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

var supportedCultures = new[] { "en", "es" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// Apply CORS Policy
app.UseCors("AllowAllPolicy");

// Add Authorization Middleware to Pipeline


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();