using Fleet.Care.Platform.VehicleOperations.Application.CommandServices;
using Fleet.Care.Platform.VehicleOperations.Application.QueryServices;
using Fleet.Care.Platform.VehicleOperations.Domain.Model.Queries;
using Fleet.Care.Platform.VehicleOperations.Interfaces.Rest.Resources;
using Fleet.Care.Platform.VehicleOperations.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Fleet.Care.Platform.VehicleOperations.Interfaces.Rest;

[ApiController]
[Route("api/v1/fuelRecords")]
[Produces("application/json")]
[Tags("Fuel Records")]
public class FuelRecordController(IFuelRecordCommandService commandService, IFuelRecordQueryService queryService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int? VehicleId = null,
        [FromQuery] int? RegisteredByUserId = null, CancellationToken cancellationToken = default)
    {
        var entities = await queryService.Handle(new GetAllFuelRecordsQuery(VehicleId, RegisteredByUserId),
            cancellationToken);
        return Ok(entities.Select(FuelRecordAssemblers.ToResource));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var entity = await queryService.Handle(new GetFuelRecordByIdQuery(id), cancellationToken);
        return entity is null ? NotFound() : Ok(FuelRecordAssemblers.ToResource(entity));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFuelRecordResource resource, CancellationToken cancellationToken)
    {
        var result = await commandService.Handle(FuelRecordAssemblers.ToCommand(resource), cancellationToken);
        var entity = result.Value!;
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, FuelRecordAssemblers.ToResource(entity));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateFuelRecordResource resource,
        CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(FuelRecordAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(FuelRecordAssemblers.ToResource(entity));
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, PatchFuelRecordResource resource,
        CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(FuelRecordAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(FuelRecordAssemblers.ToResource(entity));
    }
}