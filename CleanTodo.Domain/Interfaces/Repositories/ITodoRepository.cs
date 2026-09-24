using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Entities;

namespace CleanTodo.Domain.Interfaces.Repositories;

public interface ITodoRepository
{
    Task<List<Todo>> GetAll();
    Task<Todo?> FindById(Guid id);
    Task<Todo> Add(Todo todo);

    // Update an existing todo. Returns the updated entity.
    Task<Todo> Update(Todo todo);

    // Delete a todo by id.
    Task Delete(Guid id);
}
