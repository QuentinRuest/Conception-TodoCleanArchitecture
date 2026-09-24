using CleanTodo.Domain.Entities;

namespace CleanTodo.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAll();

    Task<User?> FindById(Guid id);

    Task<User?> FindByUsername(string username);

    Task<User> Add(User user);
}