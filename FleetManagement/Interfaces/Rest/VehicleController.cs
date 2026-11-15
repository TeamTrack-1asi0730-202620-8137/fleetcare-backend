using Fleet.Care.Platform.FleetManagement.Application.CommandServices;
using Fleet.Care.Platform.FleetManagement.Application.QueryServices;
using Fleet.Care.Platform.FleetManagement.Domain.Model.Queries;
using Fleet.Care.Platform.FleetManagement.Interfaces.Rest.Resources;
using Fleet.Care.Platform.FleetManagement.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Fleet.Care.Platform.FleetManagement.Interfaces.Rest;

[ApiController]
[Route("api/v1/vehicles")]
[Produces("application/json")]
[Tags("Vehicles")]
public class VehicleController(IVehicleCommandService commandService, IVehicleQueryService queryService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int? FleetId = null, [FromQuery] string? PlateNumber = null,
        [FromQuery] string? Status = null, CancellationToken cancellationToken = default)
    {
        var entities =
            await queryService.Handle(new GetAllVehiclesQuery(FleetId, PlateNumber, Status), cancellationToken);
        return Ok(entities.Select(VehicleAssemblers.ToResource));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var entity = await queryService.Handle(new GetVehicleByIdQuery(id), cancellationToken);
        return entity is null ? NotFound() : Ok(VehicleAssemblers.ToResource(entity));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateVehicleResource resource, CancellationToken cancellationToken)
    {
        var result = await commandService.Handle(VehicleAssemblers.ToCommand(resource), cancellationToken);
        var entity = result.Value!;
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, VehicleAssemblers.ToResource(entity));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateVehicleResource resource, CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(VehicleAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(VehicleAssemblers.ToResource(entity));
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, PatchVehicleResource resource, CancellationToken cancellationToken)
    {
        var entity = await commandService.Handle(VehicleAssemblers.ToCommand(id, resource), cancellationToken);
        return entity is null ? NotFound() : Ok(VehicleAssemblers.ToResource(entity));
    }
}