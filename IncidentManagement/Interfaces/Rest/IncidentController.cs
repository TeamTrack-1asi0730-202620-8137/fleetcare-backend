using Fleet.Care.Platform.IncidentManagement.Application.CommandServices;
using Fleet.Care.Platform.IncidentManagement.Application.QueryServices;
using Fleet.Care.Platform.IncidentManagement.Domain.Model.Queries;
using Fleet.Care.Platform.IncidentManagement.Interfaces.Rest.Resources;
using Fleet.Care.Platform.IncidentManagement.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Fleet.Care.Platform.IncidentManagement.Interfaces.Rest;

[ApiController]
[Route("api/v1/incidents")]
[Produces("application/json")]
[Tags("Incidents")]
public class IncidentController(IIncidentCommandService commandService, IIncidentQueryService queryService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int? VehicleId = null, [FromQuery] int? ReportedByUserId = null,
        [FromQuery] string? Status = null, [FromQuery] int? SourceInspectionId = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await queryService.Handle(
            new GetAllIncidentsQuery(VehicleId, ReportedByUserId, Status, SourceInspectionId), cancellationToken);
        return Ok(entities.Select(IncidentAssemblers.ToResource));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var entity = await queryService.Handle(new GetIncidentByIdQuery(id), cancellationToken);
        return entity is null ? NotFound() : Ok(IncidentAssemblers.ToResource(entity));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateIncidentResource resource, CancellationToken cancellationToken)
    {
        var result = await commandService.Handle(IncidentAssemblers.ToCommand(resource), cancellationToken);
        var entity = result.Value!;
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, IncidentAssemblers.ToResource(entity));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateIncidentResource resource,
        CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(IncidentAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(IncidentAssemblers.ToResource(entity));
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, PatchIncidentResource resource, CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(IncidentAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(IncidentAssemblers.ToResource(entity));
    }
}