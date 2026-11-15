using Fleet.Care.Platform.MaintenanceManagement.Application.CommandServices;
using Fleet.Care.Platform.MaintenanceManagement.Application.QueryServices;
using Fleet.Care.Platform.MaintenanceManagement.Domain.Model.Queries;
using Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest.Resources;
using Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Fleet.Care.Platform.MaintenanceManagement.Interfaces.Rest;

[ApiController]
[Route("api/v1/maintenanceRecords")]
[Produces("application/json")]
[Tags("Maintenance Records")]
public class MaintenanceRecordController(
    IMaintenanceRecordCommandService commandService,
    IMaintenanceRecordQueryService queryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int? MaintenancePlanId = null,
        [FromQuery] int? VehicleId = null, [FromQuery] string? MaintenanceType = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await queryService.Handle(
            new GetAllMaintenanceRecordsQuery(MaintenancePlanId, VehicleId, MaintenanceType), cancellationToken);
        return Ok(entities.Select(MaintenanceRecordAssemblers.ToResource));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var entity = await queryService.Handle(new GetMaintenanceRecordByIdQuery(id), cancellationToken);
        return entity is null ? NotFound() : Ok(MaintenanceRecordAssemblers.ToResource(entity));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMaintenanceRecordResource resource,
        CancellationToken cancellationToken)
    {
        var result = await commandService.Handle(MaintenanceRecordAssemblers.ToCommand(resource), cancellationToken);
        var entity = result.Value!;
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, MaintenanceRecordAssemblers.ToResource(entity));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateMaintenanceRecordResource resource,
        CancellationToken cancellationToken)
    {
        var entity =
            await commandService.Handle(MaintenanceRecordAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(MaintenanceRecordAssemblers.ToResource(entity));
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, PatchMaintenanceRecordResource resource,
        CancellationToken cancellationToken)
    {
        var entity =
            await commandService.Handle(MaintenanceRecordAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(MaintenanceRecordAssemblers.ToResource(entity));
    }
}