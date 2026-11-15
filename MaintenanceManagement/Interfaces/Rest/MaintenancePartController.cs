using Fleet.Care.Platform.MaintenanceManagement.Application.CommandServices;
using Fleet.Care.Platform.MaintenanceManagement.Application.QueryServices;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Queries;
using Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest.Resources;
using Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest;

[ApiController]
[Route("api/v1/maintenanceParts")]
[Produces("application/json")]
[Tags("Maintenance Parts")]
public class MaintenancePartController(
    IMaintenancePartCommandService commandService,
    IMaintenancePartQueryService queryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int? MaintenanceRecordId = null,
        CancellationToken cancellationToken = default)
    {
        var entities =
            await queryService.Handle(new GetAllMaintenancePartsQuery(MaintenanceRecordId), cancellationToken);
        return Ok(entities.Select(MaintenancePartAssemblers.ToResource));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var entity = await queryService.Handle(new GetMaintenancePartByIdQuery(id), cancellationToken);
        return entity is null ? NotFound() : Ok(MaintenancePartAssemblers.ToResource(entity));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMaintenancePartResource resource, CancellationToken cancellationToken)
    {
        var result = await commandService.Handle(MaintenancePartAssemblers.ToCommand(resource), cancellationToken);
        var entity = result.Value!;
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, MaintenancePartAssemblers.ToResource(entity));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateMaintenancePartResource resource,
        CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(MaintenancePartAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(MaintenancePartAssemblers.ToResource(entity));
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, PatchMaintenancePartResource resource,
        CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(MaintenancePartAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(MaintenancePartAssemblers.ToResource(entity));
    }
}