using CleanTodo.Application.UseCase;
using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ShipController(
    GetShipUseCase getShipUseCase
) : ControllerBase
{
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
}
