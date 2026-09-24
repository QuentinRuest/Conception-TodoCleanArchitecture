using CleanTodo.Application.Services;
using CleanTodo.Application.UseCases;
using CleanTodo.Domain.DTOS;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly LoginUseCase _loginUseCase;
    private readonly RegisterUseCase _registerUseCase;
    private readonly JwtService _jwtService;

    public AuthController(
        LoginUseCase loginUseCase,
        RegisterUseCase registerUseCase,
        JwtService jwtService)
    {
        _loginUseCase = loginUseCase;
        _registerUseCase = registerUseCase;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(
        [FromBody] RegisterDto registerDto)
    {
        try
        {
            await _registerUseCase.Execute(registerDto);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        [FromBody] LoginDto loginDto)
    {
        if (!await _loginUseCase.Execute(loginDto))
        {
            return Unauthorized();
        }
        var token = _jwtService.GenerateToken(1, loginDto.Username);
        return Ok(new { Token = token });
    }
}