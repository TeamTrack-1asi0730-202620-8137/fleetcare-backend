using Fleet.Care.Platform.InspectionManagement.Application.CommandServices;
using Fleet.Care.Platform.InspectionManagement.Application.QueryServices;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Queries;
using Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;
using Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest;

[ApiController]
[Route("api/v1/checklistItems")]
[Produces("application/json")]
[Tags("Checklist Items")]
public class ChecklistItemController(
    IChecklistItemCommandService commandService,
    IChecklistItemQueryService queryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int? ChecklistId = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await queryService.Handle(new GetAllChecklistItemsQuery(ChecklistId), cancellationToken);
        return Ok(entities.Select(ChecklistItemAssemblers.ToResource));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var entity = await queryService.Handle(new GetChecklistItemByIdQuery(id), cancellationToken);
        return entity is null ? NotFound() : Ok(ChecklistItemAssemblers.ToResource(entity));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateChecklistItemResource resource, CancellationToken cancellationToken)
    {
        var result = await commandService.Handle(ChecklistItemAssemblers.ToCommand(resource), cancellationToken);
        var entity = result.Value!;
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, ChecklistItemAssemblers.ToResource(entity));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateChecklistItemResource resource,
        CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(ChecklistItemAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(ChecklistItemAssemblers.ToResource(entity));
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, PatchChecklistItemResource resource,
        CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(ChecklistItemAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(ChecklistItemAssemblers.ToResource(entity));
    }
}