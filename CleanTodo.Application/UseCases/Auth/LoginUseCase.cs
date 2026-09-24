using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Interfaces.Repositories;

namespace CleanTodo.Application.UseCases
{
    public class LoginUseCase
    {
        private readonly IUserRepository _userRepository;

        public LoginUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Execute(LoginDto loginDto)
        {
            User user =
                await _userRepository.FindByUsername(loginDto.Username);

            if (user == null)
            {
                return false;
            }

            return BCrypt.Net.BCrypt.Verify(
                loginDto.Password,
                user.Password
            );
        }
    }
}