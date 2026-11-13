using Fleet.Care.Platform.VehicleOperations.Application.CommandServices;
using Fleet.Care.Platform.VehicleOperations.Application.QueryServices;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Queries;
using Fleet.Care.Platform.VehicleOperations.Interfaces.Rest.Resources;
using Fleet.Care.Platform.VehicleOperations.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Fleet.Care.Platform.VehicleOperations.Interfaces.Rest;

[ApiController]
[Route("api/v1/mileageRecords")]
[Produces("application/json")]
[Tags("Mileage Records")]
public class MileageRecordController(
    IMileageRecordCommandService commandService,
    IMileageRecordQueryService queryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int? VehicleId = null,
        [FromQuery] int? RegisteredByUserId = null, CancellationToken cancellationToken = default)
    {
        var entities = await queryService.Handle(new GetAllMileageRecordsQuery(VehicleId, RegisteredByUserId),
            cancellationToken);
        return Ok(entities.Select(MileageRecordAssemblers.ToResource));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var entity = await queryService.Handle(new GetMileageRecordByIdQuery(id), cancellationToken);
        return entity is null ? NotFound() : Ok(MileageRecordAssemblers.ToResource(entity));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMileageRecordResource resource, CancellationToken cancellationToken)
    {
        var result = await commandService.Handle(MileageRecordAssemblers.ToCommand(resource), cancellationToken);
        var entity = result.Value!;
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, MileageRecordAssemblers.ToResource(entity));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateMileageRecordResource resource,
        CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(MileageRecordAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(MileageRecordAssemblers.ToResource(entity));
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, PatchMileageRecordResource resource,
        CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(MileageRecordAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(MileageRecordAssemblers.ToResource(entity));
    }
}