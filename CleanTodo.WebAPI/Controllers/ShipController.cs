using CleanTodo.Application.UseCase;
using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ShipController(
) : ControllerBase
{
    [HttpGet]
    [Route("ping")]
    public async Task<IActionResult> Ping()
    {
        return Ok("pong");
    }
}
