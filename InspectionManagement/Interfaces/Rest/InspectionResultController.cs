using Fleet.Care.Platform.InspectionManagement.Application.CommandServices;
using Fleet.Care.Platform.InspectionManagement.Application.QueryServices;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Queries;
using Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;
using Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest;

[ApiController]
[Route("api/v1/inspectionResults")]
[Produces("application/json")]
[Tags("Inspection Results")]
public class InspectionResultController(
    IInspectionResultCommandService commandService,
    IInspectionResultQueryService queryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int? InspectionId = null,
        [FromQuery] int? ChecklistItemId = null, CancellationToken cancellationToken = default)
    {
        var entities = await queryService.Handle(new GetAllInspectionResultsQuery(InspectionId, ChecklistItemId),
            cancellationToken);
        return Ok(entities.Select(InspectionResultAssemblers.ToResource));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var entity = await queryService.Handle(new GetInspectionResultByIdQuery(id), cancellationToken);
        return entity is null ? NotFound() : Ok(InspectionResultAssemblers.ToResource(entity));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateInspectionResultResource resource,
        CancellationToken cancellationToken)
    {
        var result = await commandService.Handle(InspectionResultAssemblers.ToCommand(resource), cancellationToken);
        var entity = result.Value!;
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, InspectionResultAssemblers.ToResource(entity));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateInspectionResultResource resource,
        CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(InspectionResultAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(InspectionResultAssemblers.ToResource(entity));
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, PatchInspectionResultResource resource,
        CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(InspectionResultAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(InspectionResultAssemblers.ToResource(entity));
    }
}