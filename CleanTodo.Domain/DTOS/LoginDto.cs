using System.ComponentModel.DataAnnotations;

namespace CleanTodo.Domain.DTOS;

public class LoginDto
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}