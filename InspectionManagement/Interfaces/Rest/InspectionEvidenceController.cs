using Fleet.Care.Platform.InspectionManagement.Application.CommandServices;
using Fleet.Care.Platform.InspectionManagement.Application.QueryServices;
using Fleet.Care.Platform.InspectionManagement.Domain.Model.Queries;
using Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Resources;
using Fleet.Care.Platform.InspectionManagement.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Fleet.Care.Platform.InspectionManagement.Interfaces.Rest;

[ApiController]
[Route("api/v1/inspectionEvidences")]
[Produces("application/json")]
[Tags("Inspection Evidences")]
public class InspectionEvidenceController(
    IInspectionEvidenceCommandService commandService,
    IInspectionEvidenceQueryService queryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int? InspectionId = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await queryService.Handle(new GetAllInspectionEvidencesQuery(InspectionId), cancellationToken);
        return Ok(entities.Select(InspectionEvidenceAssemblers.ToResource));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var entity = await queryService.Handle(new GetInspectionEvidenceByIdQuery(id), cancellationToken);
        return entity is null ? NotFound() : Ok(InspectionEvidenceAssemblers.ToResource(entity));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateInspectionEvidenceResource resource,
        CancellationToken cancellationToken)
    {
        var result = await commandService.Handle(InspectionEvidenceAssemblers.ToCommand(resource), cancellationToken);
        var entity = result.Value!;
        return CreatedAtAction(nameof(GetById), new { id = entity.Id },
            InspectionEvidenceAssemblers.ToResource(entity));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateInspectionEvidenceResource resource,
        CancellationToken cancellationToken)
    {
        var entity =
            await commandService.Handle(InspectionEvidenceAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(InspectionEvidenceAssemblers.ToResource(entity));
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, PatchInspectionEvidenceResource resource,
        CancellationToken cancellationToken)
    {
        var entity =
            await commandService.Handle(InspectionEvidenceAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(InspectionEvidenceAssemblers.ToResource(entity));
    }
}