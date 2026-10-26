using CleanTodo.Application.UseCase;
using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Exceptions;
using CleanTodo.Domain.Interfaces.Gateway;
using CleanTodo.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ShipController(
    GetShipUseCase getShipUseCase,
    CreateShipUseCase createShipUseCase,
    UpdateShipUseCase updateShipUseCase,
    DeleteShipUseCase deleteShipUseCase,
    GetAllShipsUseCase getAllShipsUseCase,
    GetAllPortsUseCase getAllPortsUseCase,
    DockShipUseCase dockShipUseCase,
    SailShipUseCase sailShipUseCase

) : ControllerBase
{
    private CreateShipUseCase _createShipUseCase = createShipUseCase;
    private GetAllShipsUseCase _getAllShipsUseCase = getAllShipsUseCase;
    private DeleteShipUseCase _deleteShipUseCase = deleteShipUseCase;
    private UpdateShipUseCase _updateShipUseCase = updateShipUseCase;
    private readonly IShipRepository _shipRepository;
    private readonly IPirateBrokerGateway _pirateBrokerGateway;

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            ShipDto ship = await getShipUseCase.Execute(id);
            return Ok(ship);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<ShipDto>> Create([FromBody] CreateShipDto createShipDto)
    {
        try
        {
            ShipDto ship = await _createShipUseCase.Execute(createShipDto);
            return CreatedAtAction(nameof(Get), new { id = ship.Id }, ship);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ShipUpdateDto dto)
    {
        try
        {
            await _updateShipUseCase.Execute(id, dto);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _deleteShipUseCase.Execute(id);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
    [Authorize]
    [HttpGet("ports")]
    public async Task<ActionResult<List<string>>> GetPorts()
    {
        var ports = await getAllPortsUseCase.Execute();
        return Ok(ports);
    }
    [HttpPost("dock")]
    public async Task<IActionResult> Dock([FromBody] BrokerShipDto dto)
    {
        var ship = await dockShipUseCase.Execute(dto);

        return Ok(new
        {
            success = true,
            message = "Le bateau est arrivé au port.",
            ship
        });
    }
    [HttpPost("sail")]
    public async Task Execute(Guid id, string destination)
    {
        var ship = await _shipRepository.FindById(id);

        if (ship == null)
        {
            throw new CleanTodo.Domain.Exceptions.NotFoundException(id);
        }

        var ports = await _pirateBrokerGateway.GetAllPorts();

        if (!ports.Contains(destination))
        {
            throw new InvalidOperationException(
                "Le port de destination n'existe pas."
            );
        }

        await _pirateBrokerGateway.Sail(ship, destination);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllShips()
    {
        var ships = await _getAllShipsUseCase.Execute();
        return Ok(ships);
    }

}
