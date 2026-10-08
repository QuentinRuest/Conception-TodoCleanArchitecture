using CleanTodo.Domain.Entities;

namespace CleanTodo.Domain.Interfaces.Repositories;

public interface IShipRepository
{
    Task<List<Ship>> GetAll();
    Task<Ship> FindById(Guid id);
    Task<Ship> Add(Ship ship);

    // Update an existing ship. Returns the updated entity.
    Task<Ship> Update(Ship ship);

    // Delete a ship by id.
    Task Delete(Guid id);
}
