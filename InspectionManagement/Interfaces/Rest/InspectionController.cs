using Fleet.Care.Platform.InspectionManagement.Application.CommandServices;
using Fleet.Care.Platform.InspectionManagement.Application.QueryServices;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Queries;
using Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;
using Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest;

[ApiController]
[Route("api/v1/inspections")]
[Produces("application/json")]
[Tags("Inspections")]
public class InspectionController(IInspectionCommandService commandService, IInspectionQueryService queryService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int? VehicleId = null, [FromQuery] int? ChecklistId = null,
        [FromQuery] int? DriverId = null, [FromQuery] string? Status = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await queryService.Handle(new GetAllInspectionsQuery(VehicleId, ChecklistId, DriverId, Status),
            cancellationToken);
        return Ok(entities.Select(InspectionAssemblers.ToResource));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var entity = await queryService.Handle(new GetInspectionByIdQuery(id), cancellationToken);
        return entity is null ? NotFound() : Ok(InspectionAssemblers.ToResource(entity));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateInspectionResource resource, CancellationToken cancellationToken)
    {
        var result = await commandService.Handle(InspectionAssemblers.ToCommand(resource), cancellationToken);
        var entity = result.Value!;
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, InspectionAssemblers.ToResource(entity));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateInspectionResource resource,
        CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(InspectionAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(InspectionAssemblers.ToResource(entity));
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, PatchInspectionResource resource,
        CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(InspectionAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(InspectionAssemblers.ToResource(entity));
    }
}