using Fleet.Care.Platform.FleetManagement.Application.CommandServices;
using Fleet.Care.Platform.FleetManagement.Application.QueryServices;
using Fleet.Care.Platform.FleetManagement.Domain.Model.Queries;
using Fleet.Care.Platform.FleetManagement.Interfaces.Rest.Resources;
using Fleet.Care.Platform.FleetManagement.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Fleet.Care.Platform.FleetManagement.Interfaces.Rest;

[ApiController]
[Route("api/v1/fleets")]
[Produces("application/json")]
[Tags("Fleets")]
public class FleetController(IFleetCommandService commandService, IFleetQueryService queryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var entities = await queryService.Handle(new GetAllFleetsQuery(), cancellationToken);
        return Ok(entities.Select(FleetAssemblers.ToResource));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var entity = await queryService.Handle(new GetFleetByIdQuery(id), cancellationToken);
        return entity is null ? NotFound() : Ok(FleetAssemblers.ToResource(entity));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFleetResource resource, CancellationToken cancellationToken)
    {
        var result = await commandService.Handle(FleetAssemblers.ToCommand(resource), cancellationToken);
        var entity = result.Value!;
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, FleetAssemblers.ToResource(entity));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateFleetResource resource, CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(FleetAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(FleetAssemblers.ToResource(entity));
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, PatchFleetResource resource, CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(FleetAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(FleetAssemblers.ToResource(entity));
    }
}