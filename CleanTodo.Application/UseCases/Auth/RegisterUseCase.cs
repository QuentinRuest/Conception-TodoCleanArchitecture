using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Interfaces.Repositories;

namespace CleanTodo.Application.UseCases
{
    public class RegisterUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Execute(RegisterDto registerDto)
        {
            User existingUser =
                await _userRepository.FindByUsername(registerDto.Username);

            if (existingUser != null)
            {
                throw new Exception("Cet utilisateur existe déjà.");
            }

            string hashedPassword =
                BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            User user = new User(
                registerDto.Username,
                hashedPassword
            );

            return await _userRepository.Add(user);
        }
    }
}