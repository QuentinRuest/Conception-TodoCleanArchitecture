using CleanTodo.Application.UseCase;
using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PingController(
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ping()
    {
        return Ok("pong");
    }
}
