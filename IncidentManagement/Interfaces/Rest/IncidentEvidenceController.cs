using Fleet.Care.Platform.IncidentManagement.Application.CommandServices;
using Fleet.Care.Platform.IncidentManagement.Application.QueryServices;
using Fleet.Care.Platform.IncidentManagement.Domain.Model.Queries;
using Fleet.Care.Platform.IncidentManagement.Interfaces.Rest.Resources;
using Fleet.Care.Platform.IncidentManagement.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Fleet.Care.Platform.IncidentManagement.Interfaces.Rest;

[ApiController]
[Route("api/v1/incidentEvidences")]
[Produces("application/json")]
[Tags("Incident Evidences")]
public class IncidentEvidenceController(
    IIncidentEvidenceCommandService commandService,
    IIncidentEvidenceQueryService queryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int? IncidentId = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await queryService.Handle(new GetAllIncidentEvidencesQuery(IncidentId), cancellationToken);
        return Ok(entities.Select(IncidentEvidenceAssemblers.ToResource));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var entity = await queryService.Handle(new GetIncidentEvidenceByIdQuery(id), cancellationToken);
        return entity is null ? NotFound() : Ok(IncidentEvidenceAssemblers.ToResource(entity));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateIncidentEvidenceResource resource,
        CancellationToken cancellationToken)
    {
        var result = await commandService.Handle(IncidentEvidenceAssemblers.ToCommand(resource), cancellationToken);
        var entity = result.Value!;
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, IncidentEvidenceAssemblers.ToResource(entity));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateIncidentEvidenceResource resource,
        CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(IncidentEvidenceAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(IncidentEvidenceAssemblers.ToResource(entity));
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, PatchIncidentEvidenceResource resource,
        CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(IncidentEvidenceAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(IncidentEvidenceAssemblers.ToResource(entity));
    }
}