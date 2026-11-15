using Fleet.Care.Platform.MaintenanceManagement.Application.CommandServices;
using Fleet.Care.Platform.MaintenanceManagement.Application.QueryServices;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Queries;
using Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest.Resources;
using Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest;

[ApiController]
[Route("api/v1/maintenancePlans")]
[Produces("application/json")]
[Tags("Maintenance Plans")]
public class MaintenancePlanController(
    IMaintenancePlanCommandService commandService,
    IMaintenancePlanQueryService queryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int? VehicleId = null,
        [FromQuery] int? RelatedIncidentId = null, [FromQuery] string? Status = null,
        [FromQuery] string? MaintenanceType = null, CancellationToken cancellationToken = default)
    {
        var entities = await queryService.Handle(
            new GetAllMaintenancePlansQuery(VehicleId, RelatedIncidentId, Status, MaintenanceType), cancellationToken);
        return Ok(entities.Select(MaintenancePlanAssemblers.ToResource));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var entity = await queryService.Handle(new GetMaintenancePlanByIdQuery(id), cancellationToken);
        return entity is null ? NotFound() : Ok(MaintenancePlanAssemblers.ToResource(entity));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMaintenancePlanResource resource, CancellationToken cancellationToken)
    {
        var result = await commandService.Handle(MaintenancePlanAssemblers.ToCommand(resource), cancellationToken);
        var entity = result.Value!;
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, MaintenancePlanAssemblers.ToResource(entity));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateMaintenancePlanResource resource,
        CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(MaintenancePlanAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(MaintenancePlanAssemblers.ToResource(entity));
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, PatchMaintenancePlanResource resource,
        CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(MaintenancePlanAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(MaintenancePlanAssemblers.ToResource(entity));
    }
}