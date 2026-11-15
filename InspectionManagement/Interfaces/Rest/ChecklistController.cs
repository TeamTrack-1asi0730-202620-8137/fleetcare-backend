using Fleet.Care.Platform.InspectionManagement.Application.CommandServices;
using Fleet.Care.Platform.InspectionManagement.Application.QueryServices;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Queries;
using Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;
using Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest;

[ApiController]
[Route("api/v1/checklists")]
[Produces("application/json")]
[Tags("Checklists")]
public class ChecklistController(IChecklistCommandService commandService, IChecklistQueryService queryService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] bool? IsActive = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await queryService.Handle(new GetAllChecklistsQuery(IsActive), cancellationToken);
        return Ok(entities.Select(ChecklistAssemblers.ToResource));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var entity = await queryService.Handle(new GetChecklistByIdQuery(id), cancellationToken);
        return entity is null ? NotFound() : Ok(ChecklistAssemblers.ToResource(entity));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateChecklistResource resource, CancellationToken cancellationToken)
    {
        var result = await commandService.Handle(ChecklistAssemblers.ToCommand(resource), cancellationToken);
        var entity = result.Value!;
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, ChecklistAssemblers.ToResource(entity));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateChecklistResource resource,
        CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(ChecklistAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(ChecklistAssemblers.ToResource(entity));
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, PatchChecklistResource resource, CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(ChecklistAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(ChecklistAssemblers.ToResource(entity));
    }
}